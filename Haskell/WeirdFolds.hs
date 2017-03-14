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
      f x acc k --Mist listasta x saadaan? Listan päälimmäinen 
        | k==0 = acc 0
        | otherwise = x:(acc (k-1))
      e = (const [])

      --Mikä on accumulaattori

-- Remove first n elements from a list
-- >>> drop 3 "m groot"
drop' :: Int -> [a] -> [a] 
drop' n = g . foldr f e
    where
      g h = h n
      f x acc k
        | k==0 = x:(acc 0)
        | otherwise = acc (k-1)
      e = (const [])
-- Hint: Write types for g, f and e first!

removeFirst' :: Eq a => a -> [a] -> [a]
removeFirst' y xs = let
  --f :: a -> (Bool->[a]) -> Bool -> [a]
  f x g p -- x ~ a, g ~ Bool,  p ~ [c], g p ~ xs, Mistä tulee p? Eikö gp:n pitäsisi tulla xs:ssästä? x tarvitsee parametrin. un ollaan rekursion pohjalla. g ~ xs, p ~ Bool 
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True --TämäTrue tuloo voimaan vasta rekursion päätyttyä? True => ei ole poistettu --False alussa kun ei poistettu ja True lopussa kun poistettu.

--foldr :: (a -> (c -> d) -> (c -> d)) -> (c -> d) -> [a] -> (c -> b)
--foldr :: (a -> b -> b) -> b -> [a] -> a
-- b ~ Bool->[a]
