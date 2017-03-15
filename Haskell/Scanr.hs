module Scanr where

myScanr :: (a -> b -> b) -> b -> [a] -> [b]
myScanr f e = foldr  (\n (x:xs) -> (f n x):(x:xs)) [e]

myScanl :: (a -> b -> b) -> b -> [a] -> [b]
myScanl fun empty = g . foldr f e
  where
    g h = empty : h empty
    f x acc k = k fun x: acc (k fun x)
    e = (const empty)
