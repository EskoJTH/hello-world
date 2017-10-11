{-#Language RankNTypes#-}

newtype Codensity m a = Codensity {runCodensity :: forall b. (a -> m b) -> m b}

instance Functor (Codensity m) where
  fmap f (Codensity g) = Codensity p where
    p f'= g $ f'. f
    
      -- p :: (b -> mc) -> mc
      -- f':: b -> mc
      -- f :: a -> b2
      -- g :: (a -> mc) -> mc
      -- p :: (b -> mc) -> mc
      
      -- (>>=) :: forall a b. m a -> (a -> m b) -> m b
      -- fmap :: (a -> b) -> f a -> f b
      -- (<*>) :: f (a -> b) -> f a -> f b 

instance Applicative (Codensity m) where
  pure = 
--  (<*>) =
