--1.Produce n random numbers, where n is taken as an argument
--En käsitä mistä randomius esimerkeissä oikein kumpuaa. Tiedän että kätetään jotain satunnasilukuja tuottavaa funktiota. En tiedä mistä seedi alussa revitään? vissiin monad joka alkaa jollain purella ja sitten ent tiiä.

--2.Roll a die until a six comes up, printing out the rolls and their numbers

--3.Parse a comma-separated list of natural numbers (such as the familiar "0,1,1,3,5,8,13,21,34")
--tämän pitäisi onnistua ihan ok Applicativellä? Koska luennot?
import Data.Char
class Functor f => ZipA f where
    zunit :: f ()
    zipp  :: f a -> f b -> f (a,b)
    
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
           p input = case runParser p1 input of --(runParser p1 input == Maybe (a,String))
                       Nothing -> Nothing
                       Just (r,leftover) -> case runParser p2 leftover of
                        Nothing -> Nothing
                        Just (r2,leftover2) -> Just ((r,r2),leftover2)

instance Applicative Parser where
  pure s = Parser s --where s =(\s -> Just ((),s))
  (<*>) fab fa = Parser p
        where 
           p input = case runParser p1 input of --(runParser p1 input == Maybe (a,String))
                       Nothing -> Nothing
                       Just (r,leftover) -> case runParser p2 leftover of
                        Nothing -> Nothing
                        Just (r2,leftover2) -> Just ((r,r2),leftover2)
                      
aDigit :: Parser Int
aDigit = Parser p
    where 
     p "" = Nothing   
     p (x:xs) 
        | isDigit x = Just (read [x],xs)
        | otherwise = Nothing
    
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

zipParseNumbers :: String -> [Int]
zipParseNumbers s = 

--4.Look up two given words from a dictionary (of type Map String String) and return a result if both are found. Easy! Maybe?
