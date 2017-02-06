
module StringExercises where
import Data.Char

shout :: String -> String
shout str 
  | str==[] = "!"
  | otherwise =
    let
      (x:xs)=str
    in
      toUpper x : shout xs

shoutWords :: String->String
shoutWords [] = "!" 
shoutWords (x:xs) 
        | x == ' ' = "! " ++  shoutWords (xs)
        | otherwise =
          toUpper x : shoutWords (xs)

shoutLines :: String->String
shoutLines text = concat (map (\x->(shout x) ++ "\n") (lines text))


      



