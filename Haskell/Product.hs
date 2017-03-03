module Exercise where
import Prelude hiding (product)

product :: [Integer] -> Integer
product [] = 1
product (x:xs) = x*product(xs)
