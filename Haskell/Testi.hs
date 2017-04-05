jotain :: String -> Either String Int
jotain x = if length x>2 then Left "kissa" else Right 2

area :: Either String Int -> String
area x = case x of
  Left a-> "ei tyhja"
  Right a-> "tyhja"

relation text =
 let
  (firstCountry,fstMult) = fstCountry (take 3 text)
  (secondCountry,sndMult) = fstCountry (drop 3 text)
 in
   case (firstCountry,secondCountry) of
    ([],_) -> 0 
    (_,[]) -> 0
    (_,_) -> (realToFrac sndMult) / (realToFrac fstMult)

fstCountry a = (a,1)
