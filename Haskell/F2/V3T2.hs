{-#LANGUAGE DeriveFunctor#-}
{-#LANGUAGE InstanceSigs#-}
--a
class Applicative f => EskoMonad f where
--    (>>>=) :: f a -> (a -> f b) -> f b
      join :: f (f a) -> f a -- Cf. concat [[a]] -> [a]
  
{-    
join :: (EskoMonad f) => f (f a) -> f a
join a = a >>>= (\x->x)
-}


(>>=) :: (EskoMonad f) => f a -> (a -> f b) -> f b
(>>=) fa afb= join (fmap afb fa)


