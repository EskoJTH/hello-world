{-#LANGUAGE DeriveFunctor#-}
{-#LANGUAGE InstanceSigs#-}
import Data.Char

newtype Parser a = Parser (String -> (String, Maybe a))

instance Functor Parser where
  fmap f (Parser x) = Parser p where
    p s = case x s of
      (s',Just a) -> (s',Just (f a))
      (s',Nothing) -> (s',Nothing)

instance Applicative Parser where
 pure :: a -> Parser a
 pure x = Parser (\ s -> (s,Just x))
 (<*>) (Parser mf) (Parser mx) = Parser p where
   p s = case mf s of
     (s',Just f) -> case mx s' of
       (s'',Just x) -> (s'', Just (f x))
       (s'',Nothing) -> (s'', Nothing)
     (s',Nothing) -> (s', Nothing)
--f a = 'b'++a
--Ei t‰ss‰ mik‰‰n liity mihink‰‰n yht‰‰n mitenk‰‰n!
--MIt‰ min‰ yrit‰n t‰ss‰ tehd‰? Ainut tapa mitenk‰ min‰ t‰t‰ osaan ajatella on ett‰ haluan k‰yd‰ tuon kohde listan l‰pi. Sitten riippuen siit‰ onko arvo luku vai pilkku, tallenan sen johonkin listaan tai j‰t‰n pois listasta. Miksi min‰ tarvitsen t‰h‰n teh‰tv‰‰n  mit‰‰n kolmen rivin rekursiota vaikeampaa? Enkˆ min‰ halua ker‰t‰ tuonne Maybe a:n alle listan oikeita tuloksia ja jotenkin vied‰ sit‰ listaa eteenp‰in niin ett‰ saan sen lopulta ulos? Mit‰ ... nuo Stringit tuolla oikein tekee?

--laskeYksiKasa s = pure choose <*>

kasaaFunktiot s = Parser (\(x:xs) -> (xs,f x)) where f =

strinki = "1,12,3,4,45,6,7"

parseInt a
  |isDigit a = (Just a)
  |otherwise = Nothing

parseComma a
  |isComma a = Just a
  |otherwise = Nothing

isComma a
  | a == ',' = True
  | otherwise = False

juggler :: x ->  Parser -> Parser
juggler = 

choose x = case parseInt x of
  a -> Just [a]
  Nothing -> b where
    b=case parseComma x of
        a -> Just []
        Nothing -> Nothing

--applyString = 

--applicativeChoose


{-
pList = (:) <$> pnum <*> pList <|> pEnd

LiftA0 f = pure f
LiftA1 f a = pure f <*> a = f <$> a
LiftA2 f a b = f <$> a <*> b
LiftA3 f a b c = f <$> a <*> b <*> c = liftA2 f a b <*> c


liftA2 :: (a -> b -> c) -> f a -> f b -> f c
Lift a binary function to actions.

Some functors support an implementation of liftA2 that is more efficient than the default one. In particular, if fmap is an expensive operation, it is likely better to use liftA2 than to fmap over the structure and then use <*>.
-}
