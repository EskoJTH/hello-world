
module Exercise where
import Data.List

deal :: [a] -> ([a],[a])
deal list = splitAt ((length list)`quot`2) list

merge ::  Ord a => [a] -> [a] -> [a]
merge [] [] = []
merge (x:xs) (y:ys) 
    |x<=y = x:merge xs (y:ys)
    |otherwise = y:merge (x:xs) ys
merge [] list = list
merge list [] = list

mergeSort :: Ord a => [a] -> [a]
mergeSort []=[]
mergeSort [x]=[x]
mergeSort (x:xs)
 |null (drop 2 (x:xs)) = merge [x] xs
 |otherwise =
    let
        (a,b)=deal (x:xs)
    in
        merge(mergeSort a)(mergeSort b)
