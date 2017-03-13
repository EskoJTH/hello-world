module Folds where

length' :: [a] -> Int
length' a = foldr (\x xs -> 1 + xs) 0 a
concat' :: [[a]] -> [a]
concat' = foldr (\x xs -> x ++ xs) []
remove' :: Eq a => a -> [a] -> [a]
remove' a = foldr (\x xs -> if x==a then xs else x:xs) []
find' :: (a->Bool) -> [a] -> Maybe a
find' f a = foldr (\x xs -> if f x then Just x else xs) Nothing a
filter' :: (a->Bool) -> [a] -> [a]
filter' f a = foldr (\x xs -> if f x then xs else x:xs) [] a 
take' :: Int -> [a] -> [a]
take' n list = foldr step [] list
  where
    step x xs | (length xs > n) = x : xs
              | otherwise = xs
nub' :: Eq a => [a] -> [a]
nub' = foldr (\x xs -> x:remove' x xs) []
