--Minä olen kyllä vieläkin tämän kanssa ihan hukassa.

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True

--Minne tuo viimeinen True oikein menee? Eikö sen pitäisi jäädä foldr:in lopputuloksen parametriksi? Mitenkä tuo funktio 'f' voi ottaa 3 parameteriä? Mitääh? foldr :: (a -> (c -> d) -> (c -> d)) -> (c -> d) -> [a] -> (c ->b)

-- foldr :: (a -> f -> f) -> f -> [a] -> f

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True

Eikös tässä nyt käy tuolla foldin rekursion "pohjalla" sillätavalla että ensin funktiolle f  annetaan parametreiksi (const []) eli tyyppiä funktio Bool->[a] ja sitten [] eli

f :: (Bool->[a])->[]->jotakin

Sitten seuraavalla rekursion kierroksella f saa arvokseen seuraavan arvon listasta eli tyyppiä a ja vanha tulos annetaan seuraavana parametrinä.

f :: a->jotakin->jotakinjotakin

Mikä minun ajatuksissa menee pieleen?
