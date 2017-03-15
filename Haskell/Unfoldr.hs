{-#LANGUAGE ScopedTypeVariables#-}
module Unfoldr where

unfoldr :: (b-> Maybe (a,b)) -> b -> [a]
unfoldr f b = case f b of
        Just (x,y) -> x : unfoldr f y
        Nothing -> []

infiniteNaturalNumbersUnfold :: Int -> String
infiniteNaturalNumbersUnfold x = show (take x (unfoldr (\b-> Just (b,b+1)) 0 ))
main :: IO()
main = do
  putStrLn  "montako tulostetaan? (Anna Int tai kuolen D:)"
  howFar <- getLine
  let text = infiniteNaturalNumbersUnfold  x
        where x = read howFar :: Int
  putStrLn text

zip :: ([a],[b]) -> [(a,b)]
zip inp = unfoldr (\(a,b) -> if tyhja (a,b) then Nothing else Just (kissa a b)) inp
  where
    kissa :: [a] -> [b] -> ((a,b),([a],[b])) 
    kissa (a:as) (b:bs) = ((a,b),(as,bs))
    tyhja (a,b) = case (a,b) of
      ([],[]) -> True
      ([],_) -> True
      (_,[]) -> True
      _ -> False
