{-# LANGUAGE InstanceSigs #-}
{-# LANGUAGE DeriveFunctor #-}


import Data.Char
import Data.Bool
import Control.Applicative 
import Data.Map.Lazy as M

funktio :: Int -> Int -> Int
funktio x y = x + y

funktio2 :: (Int->Int->Int)->Int
funktio2 f = f 10 10

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
   | p && x == y = g False
   | otherwise = x : g p in
    Prelude.foldr f (const []) xs True
  --x on toiseksi viimeinen juttu jonossa g on viimeinen Ja True valuu P:hen

dictionary :: Map String String 
dictionary = insert "canary berd" "Some sort of berd I guess.." $
    insert "moose" "Like's forests, Dosen't like moose flies" $
    insert "fox" "Lives in a foxhole" $
    singleton "cat" "An animal that does have ears and whiskers and a tail"

newtype TuplaMap s = TuplaMap {lueTupla :: (String,String) -> Maybe s}
instance Applicative TuplaMap where
  pure s = TuplaMap (\(x,y) -> Just s)
  (<*>) (TuplaMap mf) (TuplaMap ma) = TuplaMap p where
    p s = case mf s of
      Nothing -> Nothing
      Just f -> case ma s of
        Nothing -> Nothing
        Just a -> Just (f a)
{-
instance Alternative TuplaMap where
  empty = TuplaMap (\(s1,s2)->(s,Nothing))
  (<|>) (Parser a) (Parser b) = Parser fun where
    fun s = case a s of
      (s', Just k) -> a s
      (s', Nothing) -> b s
-}

--iteroi n = (:) <$> MyRandom next' <*> iteroi (n - 1)
-- applikatiivi :: f (a -> b) -> f a -> f b
onkoYksi = TuplaMap eka <*> TuplaMap toka -- <|> Control.Applicative.empty


--(!?) m k= M.lookup k m --Jostain syystä emacs ei löytänyt (!?) operaatiota. Pitää tehdä tälle jotakin joskus kun kerkeän.

eka :: (String,String) -> Maybe (String->String)
eka s = case M.(!?) dictionary fst s of
  Nothing -> Nothing
  Just a -> Just fun where
    fun x = ("Fisrt search " ++ fst s ++ ": "++ a ++"; Second search " ++ snd s ++ ": "++  x)

                    --if x==(Just t) then Just (t,x) else Nothing)
  
toka :: (String,String) -> Maybe String
toka s = M.(!?) dictionary snd s

etsiTietokirjasta s1 s2 = case (lueTupla onkoYksi) (s1,s2) of
  Just a -> a
  Nothing -> "Could not find both words from the dictionary"


main = do f
  
f = ask >>= h
  
ask = putStrLn "Are you the killer?(y/n)" >> getLine

h s = case p s of
  Left a -> a
  Right a -> a >>= writeFile "killer.txt"

p s = case s of
  "y" -> Right $ putStrLn "Enter your ip" >> getLine
  "n" -> Left $ putStrLn "Good day to you!"
  _ -> Left f
