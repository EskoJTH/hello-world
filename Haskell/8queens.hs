module Excerise where
--En oo kyllä varmaan saanut ikinä aikaiseksi semmoista debuggaus sekamelskaa, kuin oli tämä tehtävä.

eightQueens = queens board

board = makeboard 8 8

makeboard :: Int->Int->[(Int,Int)]
makeboard a b = [(x,y) | x <- [1..a], y<-[1..b]]

queens :: [(Int,Int)]->[[(Int,Int)]]
queens [] = []
queens [(x,y),(x1,y1)] = [[(x,y)],[(x1,y1)]]
queens [(x,y)] = [[(x,y)]]
queens ((x,y):s) =
  let
    biggestX=maxX 0 ((x,y):s)
    biggestY=maxY 0 ((x,y):s)
    t1 = queens (makeboard biggestY (quot biggestX 2))
    temp = queens (makeboard biggestY (biggestX - (quot biggestX 2)))
    t2 = map (myGrow (quot x 2)) temp ---missämissämisson looppi, missämissämisson looppi, missämissämisson infi-nite-loo-oop-pi
  in
    concat (map (combine t1) (t2))

myGrow :: Int->[(Int,Int)]->[(Int,Int)]
myGrow x [] = []
myGrow x [(w,h)] = [(h,w+x)]
myGrow x ((w,h):s1)  = ((h,w+x): myGrow x s1)

maxX :: Int->[(Int,Int)]->Int
maxX max [] = max
maxX max ((x,y):s)
  |x>max = maxX x s
  |otherwise = maxX max s

maxY :: Int->[(Int,Int)]->Int
maxY max [] = max
maxY max ((x,y):s)
  |y>max = maxY y s
  |otherwise = maxY max s

combine :: [[(Int,Int)]]->[(Int,Int)]->[[(Int,Int)]] --Toiset toimivat tilat -> Toimiva Tila -> ...
combine [] y = [y]
combine (x:xs) y
  |not(tableThreaten x y) = y:x:combine xs y
  |otherwise = combine xs y

tableThreaten :: [(Int,Int)]->[(Int,Int)]->Bool
tableThreaten [] _= False
tableThreaten x (y:ys)
  |anyThreaten x y = True
  |otherwise = tableThreaten x ys

anyThreaten :: [(Int,Int)]->(Int,Int)->Bool
anyThreaten [] _ = False
anyThreaten (x:xs) y 
  |threaten x y = True
  |otherwise = anyThreaten xs y

threaten :: (Int,Int)->(Int,Int)->Bool
threaten (x1,y1)(x2,y2)
  | x2==x1 = True
  | y2==y1 = True
  | y1+x1==y2+x2 = True
  | y1-x1==y2-x2 = True
  | otherwise = False
