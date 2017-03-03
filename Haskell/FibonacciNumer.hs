module Main where
import Test.QuickCheck

main :: IO()
main =
  do
    number <- getLine
    putStrLn (show (fib (read number)))

fib :: Int -> Int
fib 1 = 1
fib 2 = 1
fib n =  fib (n-2) + fib (n-1)
