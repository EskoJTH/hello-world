module Exercise where
import Data.List
import Data.Ord

countLetters :: String -> [([Char],Int)]
countLetters string 
    |string == [] = []
    |otherwise = 
    let
        (x:xs)=(take 1 string)
        oneLetter = takeWhile (==x) string
        (a,b) = (take 1 oneLetter, length oneLetter)
    in
        [(a,b)] ++ countLetters (drop (length oneLetter) string)

format ::[([Char],Int)] -> String
format kissa  
    | kissa == [] = []
    | otherwise = 
    let
        [((x:xs),y)] = take 1 kissa
    in
        take y (repeat x) ++ format (drop 1 kissa)

sortTupleList (a1, b1) (a2, b2)
  | b1 < b2 = LT
  | b1 > b2 = GT
  | b1 == b2 = EQ

-- Due to the bug in the feedback-bot, this function needs to
-- be overly tightly typed. Other than for the bot, the type
-- should be the more general (Eq a, Ord a) => [a] -> [a].
freqSort :: String -> String
freqSort string =
        format (sortBy (sortTupleList) (countLetters (sort string)))
