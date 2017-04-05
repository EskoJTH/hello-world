module Harjoitukset2 where
import Data.Array
--kirjoitetaan algoritmi m kokoiseen taulukkoon t aljioita niined avain arvojen mukaan avain arvo voi olla VAPAA tai POISTETTU kaiken muun lisaksi.

data Arvo a = Arvo a | VAPAA | POISTETTU deriving (Eq,Show,Ord)

h :: Int -> Arvo Int -- i?
h k = Arvo (k+3)

lisaa :: a -> (a->Arvo Int) -> Array Int [Arvo a] -> (Array Int [Arvo a])
lisaa a h arr 
   = ( arr // [(paikka, (Arvo a):arr!paikka)])
  where Arvo paikka = h a
  

etsi :: Eq a => a -> (a->Arvo Int) -> Array Int [Arvo a] -> Maybe (Arvo a)
etsi x h arr 
  |i > fst(bounds arr) || i< snd(bounds arr) = Just (getTheOne x (arr ! i))
  |otherwise = Nothing
  where Arvo i = h x

getTheOne :: Eq a => a -> [Arvo a] -> Arvo a
getTheOne x list = recurse VAPAA x list
  where
    recurse tila x [] = tila
    recurse tila x (y:ys) = case y of
      POISTETTU -> recurse POISTETTU x ys
      VAPAA -> recurse tila x ys
      Arvo a -> if a==x then y else recurse tila x ys
    
poista :: Eq a => a -> (a->Arvo Int) -> Array Int [Arvo a] -> Array Int [Arvo a]
poista a h arr = arr // [(paikka, remove a (arr ! paikka))]
  where Arvo paikka = h a
        remove x (y:ys)
          |arvo==x = POISTETTU:ys
          |otherwise = y: remove x ys
          where Arvo arvo = y

main :: IO ()
main = 
  let
    taulukko0 = listArray (0,11) [[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA],[VAPAA]]
    taulukko1 = lisaa 1 h taulukko0
    taulukko2 = lisaa 5 h taulukko1
    taulukko3 = lisaa 1 h taulukko2
    taulukko4 = poista 1 h taulukko3
    arvo5 = etsi 1 h taulukko3
  in
    do
      putStrLn (show (taulukko0::Array Int [Arvo Int]))
      putStrLn (show taulukko1)
      putStrLn (show taulukko2)
      putStrLn (show taulukko3)
      putStrLn (show taulukko4)
      putStrLn (show arvo5)

  
  




