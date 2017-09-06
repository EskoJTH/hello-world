
funktio :: Int -> Int -> Int
funktio x y = x + y

funktio2 :: (Int->Int->Int)->Int
funktio2 f = f 10 10

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
   | p && x == y = g False
   | otherwise = x : g p in
    foldr f (const []) xs True
  --x on toiseksi viimeinen juttu jonossa g on viimeinen Ja True valuu P:hen
