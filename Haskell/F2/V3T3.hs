{-#LANGUAGE DeriveFunctor#-}
{-#LANGUAGE InstanceSigs#-}
--1.Produce n random numbers, where n is taken as an argument
--Onnistuu applicativellä koska tiedämme montako randomia haluamme etukäteen.
import System.Random
import Data.Char
--data StdGen = StdGen(Int->Int)
--Randmo >>>   next :: g -> (Int, g)
--random :: StdGen -> (a,StdGen)

--bind :: (a -> StdGen -> (b,StdGen)) -> (StdGen -> (a,StdGen)) -> (StdGen -> (b,StdGen))
--bind f x seed = let (x',seed') = x seed in f x' seed'

next' :: Int -> (Int, Int)
next' i = let
  (x,y) = next (mkStdGen i) in
  (x,x)

data MyRandom g = MyRandom {runR :: Int -> (g, Int)}
instance Functor MyRandom where
  fmap f (MyRandom x) = MyRandom p where
    p s = (f (fst (x s)),snd (x s))

 -- :: f (a -> b) -> f a -> f b
instance Applicative MyRandom where
  pure r = MyRandom (\int -> (r, int))
  (<*>) (MyRandom rf) (MyRandom rr) = MyRandom p where
    p s = ((f a), s2) where
      (f,s1)= (rf s)
      (a,s2) = (rr s1)

nRandomNums n seed = fst (runR (iteroi n) seed)

iteroi 0 = pure []
iteroi n = (:) <$> MyRandom next' <*> iteroi (n - 1) -- <|> (pure [])
--(x :) x

--nRandom :: Int -> Int -> [Int]
--nRandom n s = iteroi n (pure next s)

--2.Roll a die until a six comes up, printing out the rolls and their numbers
--Tarvitaan monoidi koska toiminnan tulost vaikuttaa tuleviin tapahtumiin.

next' :: Int -> (Int, Int)
next' i = let
  (x,y) = next (mkStdGen i) in
  (x,x)

data MyRandom g = MyRandom {runR :: Int -> (g, Int)}
instance Functor MyRandom where
  fmap f (MyRandom x) = MyRandom p where
    p s = (f (fst (x s)),snd (x s))

 -- :: f (a -> b) -> f a -> f b
instance Applicative MyRandom where
  pure r = MyRandom (\int -> (r, int))
  (<*>) (MyRandom rf) (MyRandom rr) = MyRandom p where
    p s = ((f a), s2) where
      (f,s1)= (rf s)
      (a,s2) = (rr s1)

instance Monad MyRandom where
{-  join :: Random (Random a) -> Random a -- Mikä tää joini on
  join = undefined-}
  (>>=) :: m a -> (a -> m b) -> m b
  (>>=) (MyRandom a) b = b a

nRandomNums n seed = fst (runR (iteroi n) seed)

iteroi 0 = pure []
iteroi n = (:) <$> MyRandom next' <*> iteroi (n - 1) -- <|> (pure [])
--(x :) x






--3.Parse a comma-separated list of natural numbers (such as the familiar "0,1,1,3,5,8,13,21,34")

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
     

--laskeYksiKasa s = pure choose <*>
kasaaFunktiot :: String -> String -> a ->
kasaaFunktiot s [] f = 
kasaaFunktiot s s f = Parser (\(x:xs) -> (xs,f x)) where f =

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

choose x = case parseInt x of
a -> Just [a]
Nothing -> b where
  b=case parseComma x of
     a -> Just []
     Nothing -> Nothing

--f a = 'b'++a
--Ei tässä mikään liity mihinkään yhtään mitenkään!
--MItä minä yritän tässä tehdä? Ainut tapa mitenkä minä tätä osaan ajatella on että haluan käydä tuon kohde listan läpi. Sitten riippuen siitä onko arvo luku vai pilkku, tallenan sen johonkin listaan tai jätän pois listasta. Miksi minä tarvitsen tähän tehätvään  mitään kolmen rivin rekursiota vaikeampaa? Enkö minä halua kerätä tuonne Maybe a:n alle listan oikeita tuloksia ja jotenkin viedä sitä listaa eteenpäin niin että saan sen lopulta ulos? Mitä ... nuo Stringit tuolla oikein tekee?


--tämän pitäisi onnistua ihan ok Applicativellä? Koska luennot?
{-
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

-}
--4.Look up two given words from a dictionary (of type Map String String) and return a result if both are found. Easy! Maybe?
