{-Take the Parser type from the lectures and write a parser for config files that look like this.

{numberOfRepeats = 5, useColor = True, url = "it.jyu.fi"}
You can decide the details of the config format to your own advantage, but your solution must make use of Parser (lines, words, split and such are all prohibited).-}
<<<<<<< HEAD

=======
{-#LANGUAGE DeriveFunctor#-}
{-#LANGUAGE InstanceSigs#-}
import Data.Monoid
import Data.Char

class Functor f => ZipA f where
    zunit :: f ()
    zipp  :: f a -> f b -> f (a,b) 
    -- Laws:                    
    --  1) zipp a zunit == fmap (\x -> (x,()) a
    --  2) zipp zunit a == fmap (\x -> ((),x) a
    --  3) zipp a (zipp b c) ~ zipp (zipp a b) c)
    
>>>>>>> 15b673c14c29103d1c5fdb2a48c28f07e7d6297f
newtype Parser a = Parser (String -> Maybe (a,String))
runParser :: Parser a -> String -> Maybe (a,String)
runParser (Parser p) s = p s

instance Functor Parser where
    fmap f (Parser p) = Parser g
        where
           g s = case p s of 
                    Nothing -> Nothing
                    Just (a,leftover) -> Just (f a,leftover) 

instance ZipA Parser where
    zunit = Parser (\s -> Just ((),s))
    -- zipp :: Parser a -> Parser b -> Parser (a,b)
    zipp p1 p2 = Parser p
        where 
           p input = case runParser p1 input of
                       Nothing -> Nothing
                       Just (r,leftover) -> case runParser p2 leftover of
                        Nothing -> Nothing
                        Just (r2,leftover2) -> Just ((r,r2),leftover2)
<<<<<<< HEAD

=======
                      
>>>>>>> 15b673c14c29103d1c5fdb2a48c28f07e7d6297f

aDigitTuple :: Parser (Int,Int) 
aDigitTuple = Parser p
    where
      p = undefined

aDigit :: Parser Int
aDigit = Parser p
    where 
     p "" = Nothing   
     p (x:xs) 
        | isDigit x = Just (read [x],xs)

openParenthesis :: Parser ()
openParenthesis = Parser p 
    where
     p ('(':xs) = Just ((),xs)
     p _ = Nothing

closeParenthesis :: Parser ()
closeParenthesis = Parser p 
    where
     p (')':xs) = Just ((),xs)
     p _ = Nothing
    
comma :: Parser ()
comma = Parser p 
    where
     p (',':xs) = Just ((),xs)
     p _ = Nothing

orElse :: Parser a -> Parser a -> Parser a
orElse p1 p2 = Parser p
    where
     p s = case runParser p1 s of
            Nothing -> runParser p2 s
            Just x  -> Just x
