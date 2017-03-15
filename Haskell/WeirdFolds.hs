{-#LANGUAGE ScopedTypeVariables#-}
module Exercise where
import Data.List hiding (foldl)

-- Remove the first occurrence of `x` from the argument list
removeFirst :: Eq a => a -> [a] -> [a] 
removeFirst x = g . foldr f e
    where
      g ~(a,b) = a
      f t ~(a,b) = if t==x then (b,t:b) else (t:a,t:b)
      e = ([],[])

-- Take first n elements from a list
-- >>> take 3 "I am groot"
--     "I a"
take' :: Int -> [a] -> [a] 
take' n = g . foldr f e
    where 
      g :: (Int -> [a]) -> [a]
      g h = h n
      f :: a -> (Int -> [a]) -> Int -> [a]
      f x acc k --Mist listasta x saadaan? Listan p‰‰limm‰inen 
        | k<=0 = acc 0
        | otherwise = x:(acc (k-1))
      e = (const [])

      --Mik‰ on accumulaattori

-- Remove first n elements from a list
-- >>> drop 3 "m groot"
drop' :: Int -> [a] -> [a] 
drop' n = g . foldr f e
    where
      g h = h n
      f x acc k
        | k<=0 = x:(acc 0)
        | otherwise = acc (k-1)
      e = (const [])
-- Hint: Write types for g, f and e first!

removeFirst' :: Eq a => a -> [a] -> [a]
removeFirst' y xs = let
  --f :: a -> (Bool->[a]) -> Bool -> [a]
  f x g p -- x ~ a, g ~ Bool,  p ~ [c], g p ~ xs, Mist‰ tulee p? Eikˆ gp:n pit‰sisi tulla xs:ss‰st‰? x tarvitsee parametrin. un ollaan rekursion pohjalla. g ~ xs, p ~ Bool 
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True --T‰m‰True tuloo voimaan vasta rekursion p‰‰tytty‰? True => ei ole poistettu --False alussa kun ei poistettu ja True lopussa kun poistettu.

--foldr :: (a -> (c -> d) -> (c -> d)) -> (c -> d) -> [a] -> (c -> b)
--foldr :: (a -> b -> b) -> b -> [a] -> a
-- b ~ Bool->[a]




-- Extract the first element from a list
fhead :: [a] -> Maybe a 
fhead = g . foldr f e
    where
      g :: (Int -> Maybe a) -> Maybe a
      g h = h 1
      f :: a -> (Int -> Maybe a) -> Int -> Maybe a
      f x acc k
        | k==0 = acc 0
        | otherwise = Just x
      e = (const Nothing)

-- Extract the last element from a list
flast :: [a] -> Maybe a 
flast = g . foldr f e
    where
      g h = h
      f :: a -> Maybe a -> Maybe a
      f x xs = case xs of
       Nothing -> Just x
       _ -> xs
      e = Nothing

-- Extract all but the first element of a list
ftail :: [a] -> Maybe [a]
ftail = g . foldr f e
    where
      g :: (Int ->Maybe [a]) -> Maybe [a]
      g f = f 0
      f :: a -> (Int -> Maybe [a]) -> Int -> Maybe [a]
      f x acc k
        | k==0 = Just (case acc 1 of
                Just value -> value
                Nothing -> [])
        | otherwise = Just (case acc 1 of
                Just value -> x:value
                Nothing -> [x])
      e = (const Nothing)

-- Extract all but the last element from the list
finit :: [a] -> Maybe [a]
finit = g . foldr f e
    where
      g :: Maybe [a] -> Maybe [a]
      g f = f
      f :: a -> Maybe [a] -> Maybe [a]
      f x xs = Just (case xs of
                Just value -> x:value
                Nothing -> [])
      e = Nothing
