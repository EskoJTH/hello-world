{-Implement the following functions with traverse f, where traverse is from Data.Traversable and f is your own creation.

    tminimum :: (Traversable t, Bounded a, Ord a) => t a -> a to find the minimal element
    tmap :: Traversable t => (a -> b) -> t a -> t b to consistently change all elements
    tmodify :: Traversable t => (a -> a) -> t a -> t a to change the last element if it exists
-}

import Data.Traversable 

data Min a = Min a | Empty

instance (Ord a) => Monoid (Min a) where
  mempty = Empty
  mappend (Min a) (Min b) = Min (min a b)

--traverse :: Applicative f => (a -> f b) -> t a -> f (t b)

tminimum :: (Traversable t, Bounded a, Ord a) => t a -> a
tminimum list = traverse f list where
  f = ()

tminimum' :: Ord a => [a] -> a
tminimum' list  =(\(Min a)->a) $ foldMap (\a->Min a) list

foldMaps :: (Monoid m, Traversable t) => (a -> m) -> t a -> m
foldMaps f = _1 . traverse _2


-- f a:f b:f c...

tmap :: Traversable t => (a -> b) -> t a -> t b
tmap = undefined

tmodify :: Traversable t => (a -> a) -> t a -> t a
tmodify = undefined

{-You should be able to build f from the following pieces.

    Identity from base
    Const c from base
    Min from base
    ReaderT r m from mtl
    WriterT w m from mtl
    StateT s m from mtl
    Backwards from transformers
-}
