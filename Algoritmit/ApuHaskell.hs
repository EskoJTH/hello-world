import Data.Sequence hiding (length, take, drop)
import Prelude
h k = k `mod` 10

taulu :: [Int]
taulu = [23, 47, 17, 75, 53, 33, 62, 18]

lasketaulu lista = map (\ k ->mod k 10) lista

hajo1 lista = Prelude.reverse (foldr (check'') [] (Prelude.reverse taulu))

check k ks = recurse k ks 1
  where recurse k ks i
          |elem (h k) ks = recurse (((h k) + i) `mod` 10) ks (i+1) -- +i // +i*i ... i+1
          |otherwise = h k : ks

check' k ks = recurse k ks 1
  where recurse k ks i
          |elem (h k) ks = recurse (((h k) + i*i) `mod` 10) ks (i+1) -- +i // +i*i ... i+1
          |otherwise = h k : ks

check'' k ks = recurse k ks 1
  where recurse k ks i
          |elem (h k) ks = recurse (((h k) + (i *(7 - (k `mod` 7)))) `mod` 10) ks (i+1) -- +i // +i*i ... i+1
          |otherwise = h k : ks

laskekaikki = kasaaTaulu (hajo1 taulu) taulu

kasaaTaulu siainnit alkiot = show $ fst $ foldr (\x (y,z) -> (update (head z) x y, drop 1 z)) (fromList (take 10[-1,-1..]), siainnit) (fromList (Prelude.reverse alkiot))

