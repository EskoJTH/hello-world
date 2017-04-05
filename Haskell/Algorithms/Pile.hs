module Pile where
import System.Random

main :: IO ()
main = do
  g <- newStdGen
  let
    howLong = 15 -- randomRIO (10,20)
    numerot = take howLong (randomRs (0,20) g)
    x = show $  heapSort numerot
  putStrLn (show numerot)
  putStrLn x

heapSort :: [Int]->[Int]
heapSort [] = []
heapSort x =
     degenerateToOrderedList (drop 1 (buildHeap x))

degenerateToOrderedList :: [Int]->[Int]
degenerateToOrderedList [] = []
degenerateToOrderedList (x:xs) = x: degenerateToOrderedList (fixRemoved xs)

fixRemoved :: [Int]->[Int]
fixRemoved x =
   chechRemoved fixedList 1
  where fixedList = init((last x):x)

chechRemoved :: [Int]-> Int ->[Int]
chechRemoved x i
  |i*2 > x!!0 = x --ei lapsia
  |i*2+1 <= x!!0 = case2--kaksi lasta
  |i*2 <= x!!0 = case1 --yksi lapsi
  |otherwise = [] --ei tanne
  where
    case1 
      |x!!i*2 < x!!i = let
         h = x!!i
         x1 = changeNthElement i (const (x!!i*2)) x 
         x2 = changeNthElement (i*2) (const h) x1 
         in x2
      |otherwise = x
      
    case2 
      |x!!i*2 < x!!i*2+1 = case21
      |otherwise = case22
      where
        case21
          |
          |otherwise =
        case22
          |
          |otherwise =
  
      

--generateRandomIntList [Int]
buildHeap :: [Int]->[Int] --pitaisi kayttaa Sequenceja. Meni jo.
buildHeap x
  | (x!!0)+1 == last x = x --Kun kaikki kayty lapi.
  | otherwise = (y+1):ys where --kasvatetaan ensimmaisen alkion arvoa.
    (y:ys)=checkAdded x ((x!!0)+1) --Otetaan ensimmaisen elementin kuvaama uusi elementti mukaan taulukkoon.

checkAdded :: [Int] -> Int -> [Int]
checkAdded x i
  | i==1 = x
  | x!!(div i 2) > x!!i = let
      h=x!!i
      x1=changeNthElement i (const (x!!(div i 2))) x
      x2=changeNthElement (div i 2) (const h) x1
      in checkAdded x2 (div i 2)
  |otherwise = x


changeNthElement :: Int -> (a -> a) -> [a] -> [a] --Not mi code
changeNthElement idx transform list
    | idx < 0   = list
    | otherwise = case splitAt idx list of
                    (front, element:back) -> front ++ transform element : back
                    _ -> list    -- if the list doesn't have an element at index idx
