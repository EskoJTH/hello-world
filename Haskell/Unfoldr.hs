module Unfoldr where

unfoldr :: (b-> Maybe (a,b)) -> b -> [a]
unfoldr f b = case f b of
        Just (x,y) -> x : unfoldr f y
        Nothing -> []
