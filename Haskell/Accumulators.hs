--Min� olen kyll� viel�kin t�m�n kanssa ihan hukassa.

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True

--Minne tuo viimeinen True oikein menee? Eik� sen pit�isi j��d� foldr:in lopputuloksen parametriksi? Mitenk� tuo funktio 'f' voi ottaa 3 parameteri�? Mit��h? foldr :: (a -> (c -> d) -> (c -> d)) -> (c -> d) -> [a] -> (c ->b)

-- foldr :: (a -> f -> f) -> f -> [a] -> f

removeFirst :: Eq a => a -> [a] -> [a]
removeFirst y xs = let
  f x g p
    | p && x == y = g False
    | otherwise = x : g p in
  foldr f (const []) xs True

Eik�s t�ss� nyt k�y tuolla foldin rekursion "pohjalla" sill�tavalla ett� ensin funktiolle f  annetaan parametreiksi (const []) eli tyyppi� funktio Bool->[a] ja sitten [] eli

f :: (Bool->[a])->[]->jotakin

Sitten seuraavalla rekursion kierroksella f saa arvokseen seuraavan arvon listasta eli tyyppi� a ja vanha tulos annetaan seuraavana parametrin�.

f :: a->jotakin->jotakinjotakin

Mik� minun ajatuksissa menee pieleen?
