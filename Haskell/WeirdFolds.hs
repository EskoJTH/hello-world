module Exercise where
import Data.List hiding (foldl)

-- Remove the first occurrence of `x` from the argument list
removeFirst :: Eq a => a -> [a] -> [a] 
removeFirst x = g . foldr f e
    where
      g ~(a,b) = a
      f t ~(a,b) = if t==x then (b,t:b) else (t:a,t:b)
      e = ([],[])
