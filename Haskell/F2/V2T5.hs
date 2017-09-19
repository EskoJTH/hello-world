import Data.Monoid
--{-#LANGUAGE DeriveFunctor#-}
--{-#LANGUAGE InstanceSigs#-}
newtype Identity a = Identity a
instance Functor Identity where
  fmap f (Identity a) = Identity (f a)

--a
instance Applicative Identity where
  pure = Identity
  (<*>) (Identity f) (Identity x)= Identity (f x)

--b
newtype Compose f g a = Compose (f (g a))
instance (Functor g, Functor f) => Functor (Compose f g) where
  fmap f (Compose c) = Compose fmap2 where
    fmap2 = (fmap (fmap f) c)
instance (Applicative g, Applicative f) => Applicative (Compose f g) where
  pure x = Compose (pure(pure x))
  (<*>) (Compose foo) (Compose fga) = Compose (h foo <*> fga) where
    h :: (Applicative f, Applicative g) => f(g(a -> b)) -> f(g a -> g b)
    h fo = fmap (\a-> (<*>) a) fo    
--Eipä ollu yhtään helppoa. Vaati paljon tuijjottamista ja keskittymistä, että tajusin.
--Ei ollu ohjauksissa ympärillä tapahtuvasta sählingistä paljoa hyötyä.


--C
-- as in exercise E2
newtype State s a = State (s -> (a, s))
instance Functor (State s) where
  fmap f (State fa) = State g where
    g h = (f(fst(fa h)), (snd(fa h)))
instance (Monoid s) => Applicative (State s) where
  pure a = State (\s -> (a, s))
  (<*>) (State ff) (State fa) = State (\sIn ->(fst(ff sIn) (fst(fa sIn)),sIn))
