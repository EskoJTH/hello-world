{-#LANGUAGE DeriveFunctor#-}
{-Implement the following functions with traverse f, where traverse is from Data.Traversable and f is your own creation.

    tminimum :: (Traversable t, Bounded a, Ord a) => t a -> a to find the minimal element
    tmap :: Traversable t => (a -> b) -> t a -> t b to consistently change all elements
    tmodify :: Traversable t => (a -> a) -> t a -> t a to change the last element if it exists
-}

import Data.Traversable
import Data.Functor.Const
import Data.Semigroup
import Data.Foldable

--let a;
--for (let i of lista) if (i<a) a=i; 

--data Min a = Min a deriving (Functor, Show)
{-
instance (Ord a) => Semigroup (Min a) where
  (<>) (Min a) (Min b) = Min (min a b)

instance Applicative Min where
  pure = Min
  (<*>) (Min f) (Min b) = Min(f b)
-}

tminimum :: (Traversable t, Bounded a, Ord a) => t a -> a
tminimum list = getMin $ getConst $ traverse fun list where
  fun a = Const (Min a)
-- (Const . Min)


runMinList ::(Traversable t, Ord a) => Min (t a) -> a
runMinList (Min list) =(\(Min a) -> a) $ foldMap (\a->Min a) list

tminimum'' :: (Traversable t, Bounded a, Ord a) => t a -> a
tminimum'' list = runMinList $ traverse f list where
  f = (\a->Min a)

tminimum' :: Ord a => [a] -> a
tminimum' list  = (\(Min a)->a) $ foldMap (\a->Min a) list

--traverse :: Applicative f => (a -> f b) -> t a -> f (t b)
--foldMap :: Monoid m => (a -> m) -> t a -> m

foldMaps :: (Monoid m, Traversable t) => (a -> m) -> t a -> m
foldMaps f = getConst . traverse fun where
  fun a = Const (f a)

sequenceA :: [Min a] -> Min [a]
sequenceA list = Min $ map (\(Min a) -> a) list

sequenceAC :: Monoid c => [Const c a] -> Const c [a]
sequenceAC [] = Const mempty
sequenceAC (x:xs) = Const $ getConst x `mappend` ys
  where ys = getConst $ sequenceAC xs

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
