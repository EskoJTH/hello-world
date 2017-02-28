
module Exercise where

listaTakaperin :: [a]->[a]
listaTakaperin a = reverse a

listaTakaperin' :: Int -> Int
listaTakaperin' a = "kissa"

listaTuplaTakaperin :: [a] -> [a] -> [a]
listaTuplaTakaperin = \c, a, b ->  b ++ listaTakaperin a
  ++ c
