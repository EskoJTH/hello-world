module Scanr where

myScanr :: (a -> b -> b) -> b -> [a] -> [b]
myScanr f e list= foldr  (\n (x:xs) -> (f n x):(x:xs)) [e] list

myScanl :: (b -> a -> b) -> b -> [a] -> [b]
myScanl f e list = foldl  (\(x:xs) n  -> (f x n):(x:xs)) [e] list
