{-#Language RankNTypes#-}

newtype Codensity m a = Codensity {runCodensity :: forall b. (a -> m b) -> m b}

instance Functor (Codensity m) where
  fmap f (Codensity g) = Codensity p where
    p f'= g $ f'. f
    
      -- p :: (b -> mc) -> mc
      -- f':: b -> mc
      -- f :: a -> b
      -- g :: (a -> mc) -> mc
      -- p :: (b -> mc) -> mc

      -- f' . f :: (a -> b) -> mc
      
      -- (>>=) :: forall a b. m a -> (a -> m b) -> m b
      -- fmap :: (a -> b) -> f a -> f b
      -- (<*>) :: f (a -> b) -> f a -> f b 

instance Applicative (Codensity m) where
  pure a= Codensity (\f-> f a)
  (<*>) (Codensity mf) (Codensity ma) = Codensity p where
      p f' = mf (\f -> ma (f' . f) )

      -- p :: (b -> mc) -> mc
      -- mf = ((a->b) -> mc) -> mc
      -- ma = (a -> mc) -> mc

      -- f':: b -> mc
      -- f :: a -> b
      -- g :: (a -> mc) -> mc
      -- p :: (b -> mc) -> mc

instance Monad (Codensity m) where
  (>>=) ma f = Codensity p where
    --lunttasin t�m�n suoraan Hackagesta mutta en voi sanoa ett� minulla olisi pienint�k��n hajua mit� ihmett� t�ss� oikein tapahtuu. Mit� ihmett� nuo runCodensityt tuolla tekee? En olisi t�t� itse keksinyt varmaan ikin�.
    p f' = runCodensity ma (\a->runCodensity (f a) f')
      -- p :: (b -> mc) -> mc
      -- f = a -> ((b -> mc) -> mc)
      -- ma = (a -> mc) -> mc

      -- f':: b -> mc
      -- p :: (b -> mc) -> mc
