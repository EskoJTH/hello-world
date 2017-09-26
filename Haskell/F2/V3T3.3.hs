{-#LANGUAGE DeriveFunctor#-}
{-#LANGUAGE InstanceSigs#-}
import Data.Char

newtype Parser a = Parser (String -> (String ,Maybe a))

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
       (s'',Just x) -> (s'',Just (f x))
       (s'',Nothing) -> (s'',Nothing)
     (s',Nothing) -> (s',Nothing)



   
parseInt a
  |isDigit a = Just a
  |otherwise = Nothing

parseComma a
  |isComma a = Just a
  |otherwise = Nothing

isComma a
  | a == ',' = True
  | otherwise = False

choose a = case parseInt a of
  a -> Just [a]
  Nothing -> case parseComma a of
    a -> Just []
    Nothing -> Nothing


{-
pList = (:) <$> pnum <*> pList <|> pEnd

LiftA0
LiftA1 
LiftA2 f x y = f <$> x <*> y
LiftA3


liftA2 :: (a -> b -> c) -> f a -> f b -> f c
Lift a binary function to actions.

Some functors support an implementation of liftA2 that is more efficient than the default one. In particular, if fmap is an expensive operation, it is likely better to use liftA2 than to fmap over the structure and then use <*>.
-}
