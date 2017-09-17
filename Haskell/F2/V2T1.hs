import Data.Bifunctor

--a
newtype Ehka a= Ehka {kissa :: Maybe a} deriving (Show,Eq)
instance Functor Ehka where
  fmap f (Ehka a) = case a of
    Just b -> Ehka (Just (f b))
    Nothing -> Ehka Nothing

--b
--newtype Tupula a b = Tupula (a,b) deriving (Eq,Show)
--instance Bifunctor Tupula where
--  bimap f1 f2 (Tupula (a,b)) = Tupula (f1 a, f2 b)

newtype Tupula a b = Tupula (a,b) deriving (Eq,Show)
instance Functor (Tupula a) where
  fmap f (Tupula (a,b)) = Tupula ( (a,f b))

--c
newtype ZipList a = Z [a]
instance Functor ZipList where
  fmap f (Z xs) = Z (map f xs)
