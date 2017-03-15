module Folds where
import Data.List

length' :: [a] -> Int
length' = foldl' (\xs x -> 1 + xs) 0
concat' :: [[a]] -> [a]
concat' = foldr (\x xs -> x ++ xs) []

remove' :: Eq a => a -> [a] -> [a] 
remove' n = g . foldr f e
    where
      g h = h 0  
      f x acc k
        | k==0&&x==n = acc 1
        | otherwise = x:acc k
      e = (const [])

annihilate' :: Eq a => a -> [a] -> [a]
annihilate' a = foldr (\x xs -> if x==a then xs else x:xs) []
find' :: (a->Bool) -> [a] -> Maybe a
find' f a = foldr (\x xs -> if f x then Just x else xs) Nothing a
filter' :: (a->Bool) -> [a] -> [a]
filter' f a = foldr (\x xs -> if f x then x:xs else xs) [] a

take' :: Int -> [a] -> [a]
take' n = g . foldr f e
  where
    g h = h n
    f x acc k
      | k>0 = x:acc (k-1)
      | otherwise = acc 0
    e = (const [])
    
nub' :: Eq a => [a] -> [a]
nub' = foldr (\x xs -> x:annihilate' x xs) []

--Hupsis olimpas huolimaton. pitäisi toimia nyt.
