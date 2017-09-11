import Data.Monoid
import Data.Semigroup
g :: (Foldable f, Monoid m) => ((a -> m) -> f a -> m)     ->     ((b -> a -> b) -> b -> [a] -> b)
g :: (Foldable f, Monoid m) => ((a -> m)        -> f a -> m)     ->     ((b -> a -> b) -> b -> [a] -> b) 
g =
foldl :: (b -> a -> b) -> b -> [a] -> b
foldl f e xs = g . foldMap () xs where f=(/a b->())

--(.) :: (b -> c) -> (a -> b) -> a -> c

--Taika taitaa olla monoidissa.
--(Foldable f, Monoid m) => (a -> m) -> f a -> m
-- m =? (a -> m)  ----- b
newtype Fun a b = Fun {getFun :: a->b}
instance (Monoid b) => Monoid (Fun a b) where
  mempty = Fun mempty
  mappend (Fun c) (Fun d) = Fun (\x->(c x) Data.Monoid.<> (d x))

--Insaideri tietoa käytä endoa.

newtype Endo a = Endo {appEndo :: a -> a}
instance Monoid (Endo a) where
  mempty = Endo (\a-> a)
  mappend (Endo a) (Endo b)  = Endo (a . b)
