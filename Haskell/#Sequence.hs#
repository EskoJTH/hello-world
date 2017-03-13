module Sequence where

sequence' :: [IO a] -> IO [a]
sequence' [] = pure []
sequence' (op:ops) = 
    op >>= \x ->
    sequence' ops >>= \xs->
    return (x:xs)

test = sequence' [getLine,getLine]
 
