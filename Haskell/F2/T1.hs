import Data.Monoid hiding (Sum, First, Last, Endo, Product, Min, Max, NonEmpty,Endo,Predicate)
import Data.Semigroup hiding (Sum, First, Last, Endo, Product, Min, Max, NonEmpty, Endo,Predicate)
import Data.Map
--a
newtype Count = Count {getCount :: Integer} deriving (Eq,Show)
instance Monoid Count where
  mempty = Count 0
  mappend (Count a) (Count b) =  Count (a + b)

--b
newtype Sum a = Sum {getSum :: a} deriving (Eq,Show)
instance Num a => Monoid (Sum a) where
  mempty = Sum 0
  mappend (Sum c) (Sum b)  =  Sum (c + b)
  
--c
newtype Product a = Product {getProfuct :: a} deriving (Eq,Show)
instance Num a => Monoid (Product a) where
  mempty = Product 0
  mappend (Product a) (Product b) = Product (a * b)
  

--d
newtype First a = First {getFirst :: Maybe a} deriving (Eq, Show)
instance Monoid (First a) where
  mempty = First Nothing
  mappend (First (Just a)) (First (Nothing)) = First (Just a)
  mappend (First (Nothing)) (First(Just b)) = First (Just b)
  mappend (First(Just a)) (First(Just b)) = First (Just a)
  
--e
newtype Last a = Last {getLast :: Maybe a} deriving (Eq, Show)
instance Monoid (Last a) where
  mempty = Last Nothing
  mappend (Last(Just a))(Last(Nothing)) = Last (Just a)
  mappend (Last(Nothing))(Last(Just b)) = Last (Just b)
  mappend (Last(Just a))(Last(Just b)) = Last (Just b)
  
--f
newtype Min a = Min {getMin :: a} deriving (Ord,Show,Eq)
instance Ord a => Semigroup (Min a) where
  (<>) (Min a) (Min b) 
    |a<b = Min a
    |a>b = Min b
    |otherwise = Min a

--g
newtype Max a = Max {getMax :: a} deriving (Ord,Show,Eq)
instance Ord a => Semigroup (Max a) where
  (<>) (Max b) (Max a) 
    |a<b = Max a
    |a>b = Max b
    |otherwise = Max a
--h
data NonEmpty a = a :| [a] deriving (Eq, Show)
instance Semigroup (NonEmpty a) where
  (<>) (a :| as) (b :| bs) = a :| b
  
--i
newtype MonMap k a = Mon (Map k a) deriving (Show)
instance (Ord k, Monoid m) => Monoid (MonMap k m) where
    mempty = Mon (Data.Map.empty)
    mappend (Mon m1) (Mon m2) = Mon (Data.Map.unionWith mappend m1 m2)
    
--j
newtype Predicate a = Pred (a -> Bool)
instance Semigroup (Predicate a) where
  (<>) (Pred a) (Pred b) = Predicate (a Data.Semigroup.<> b)
  
--k
newtype Endo a = Endo {appEndo :: a -> a}
instance Semigroup (Endo a) where
  (<>) a b = a . a
    
--l
newtype Fun a b = Fun {getFun :: (a->b)}
instance (Monoid b) => Semigroup (Fun a b) where
  (<>) a b = a . b
  
--m
newtype Pair a b = Pair {getPair :: (a,b)} deriving (Show)
instance (Monoid a, Monoid b) => Monoid (Pair a b) where
  mempty = Pair (mempty,mempty)
  mappend (Pair(a,b)) (Pair (c,d)) = Pair (mappend a c, mappend b d)
  
--n
instance Semigroup (IO a) where
  (<>) (a) (b) =  a >> b
