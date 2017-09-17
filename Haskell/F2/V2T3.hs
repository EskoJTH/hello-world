class Functor f => ZipA f where
  zunit :: f ()
  zzip :: f a -> f b -> f (a, b)

--a
instance ZipA Maybe where
  zunit = Nothing
  zzip Nothing _ = Nothing
  zzip _ Nothing = Nothing
  zzip (Just a) (Just b) = Just (a,b)

--b
--Ei onnistu (a,b) ei ole Funktori?
newtype Tupula a b = T (a,b) --T a b???
instance Functor (Tupula a) where
  fmap f (T t) = T ((fst t),f (snd t))
instance ZipA (Tupula a) where
  zunit = T a b
  zzip (T (a,b)) (T (a',b')) = T (fmap ,(a',b'))
--c
  --where the idea is that zzip (Z [1, 2, 3]) (Z ['a', 'b']) == Z [(1, 'a'), (2, 'b')]
newtype ZipList a = Z [a]
instance Functor ZipList where
  fmap f (Z t) = Z(map f t)
instance ZipA ZipList where
  zunit = Z []
  zzip (Z []) _ = Z []
  zzip _ (Z []) = Z []
  zzip (Z(a:as)) (Z(b:bs)) = Z((a,b):(t)) where
    t = unType (zzip (Z as) (Z bs))
    unType (Z x) = x
      
  
