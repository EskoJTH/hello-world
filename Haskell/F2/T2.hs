import Data.Time.Clock
import Data.Semigroup as Semi
import Data.Monoid as M
import Data.Foldable
import Data.List
import GHC.Exts
data Vesa =
  Vesa {project:: String, subproject :: String, starttime :: UTCTime, endtime :: UTCTime, comment :: Comment} deriving (Eq,Show)
--instance Semigroup (Vesa p1 p2 start end com) where
--  (<>) (Vesa p1 p2 start end com)  (Vesa p1' p2' start' end' com') = Vesa p1 p2 start
--  mempty = Vesa [] [] (UTCTime 0)(UTCTime 0) (Comment [])
data Answer =
  Answer {timeSpent :: TimeSpent, timeSpan :: TimeSpan, avgtime :: AvgTimeSpent, commment :: Comment} deriving (Eq,Show)
instance Monoid Answer where
  mempty = Answer mempty mempty mempty mempty
  mappend (Answer t1 t2 avgt c) (Answer t1' t2' avgt' c') = Answer (t1 M.<>t1') (t2 Semi.<>t2') (avgt M.<>avgt') (c M.<>c')

--  mempty = Vesa [] [] (UTCTime 0)(UTCTime 0) (Comment [])
--{(project:: String, subproject :: String, starttime :: UTCTime, endtime :: UTCTime, comment :: Comment)}

newtype TimeSpent = TimeSpent {getTimediff ::  NominalDiffTime} deriving (Eq,Show,Ord)
instance Monoid TimeSpent where
  mempty = TimeSpent 0
  mappend (TimeSpent a) (TimeSpent b) = TimeSpent (a + b)
  
newtype  AvgTimeSpent = AvgTimeSpent{getAvgTime :: NominalDiffTime} deriving (Eq,Show,Ord)
instance Monoid AvgTimeSpent where
  mempty = AvgTimeSpent 0
  mappend (AvgTimeSpent a) (AvgTimeSpent b) = AvgTimeSpent((a+b)/2)
  
newtype TimeSpan = TimeSpan {getTime :: Maybe (UTCTime,UTCTime)} deriving (Eq,Show,Ord)
instance Monoid TimeSpan where
  mempty = TimeSpan Nothing
  mappend (TimeSpan Nothing) (TimeSpan (Just(c,d))) = TimeSpan (Just (c,d))
  mappend (TimeSpan (Just (a,b))) (TimeSpan Nothing) = TimeSpan (a,b)
  mappend (TimeSpan (Just (a,b))) (TimeSpan (Just (c,d))) = TimeSpan (Just (min a c, max b d))
  
newtype Comment = Comment {getComment :: String} deriving (Eq,Show,Ord)
instance Monoid Comment  where
  mempty = Comment []
  mappend (Comment a) (Comment b) = Comment (a ++ " " ++ b)
  
data Vesat a = Vesat {a ::[Vesa]} deriving (Eq,Show)
instance Monoid (Vesat a) where
  mempty = Vesat []
  mappend (Vesat a) (Vesat b) = Vesat (a ++ b)

--tulosta projektit = tulostaAnswers (kasiteleProjektit projektit)
--tulostaAnswers x:xs = 
--tulostaAnswer vastaukset=
jarjesta :: [Vesa] ->[[Vesa]]
jarjesta vesat = groupBy groupHelper (sortWith (\(Vesa a b c d e)->a) vesat)

groupHelper (Vesa a b c d e) (Vesa a' b' c' d' e') = if(a==(a'))then True else False

kasiteleProjektit :: [[Vesa]]->[Answer]
kasiteleProjektit (projekti:projektit) = (convertter projekti):kasiteleProjektit(projektit)
convertter :: [Vesa]->Answer
convertter vesat = foldMap (convert) vesat
convert :: Vesa->Answer
convert (Vesa p1 p2 start end com) =
  Answer (TimeSpent (diffUTCTime start end)) (TimeSpan (start,end)) (AvgTimeSpent(diffUTCTime start end)) (com)

convertter' :: [Vesa]->Answer
convertter' [(Vesa p1 p2 start end com)] =
  Answer (TimeSpent (diffUTCTime start end)) (TimeSpan (start,end)) (AvgTimeSpent(diffUTCTime start end)) (com)
convertter' (vesa:vesat) =(convertter [vesa]) M.<> (convertter vesat)

--laske :: [Vesa]->String
--laske ((Vesa p1 p2 start end com):projektit) = 

--Timespan ja kommentti lˆytyy t‰st‰.
--data ToistottomatVesat a = ToistottomatVesat {a ::[Vesa String String UTCTime UTCTime Comment]} deriving (Eq,Show)
--instance Monoid (ToistottomatVesat a) where
--  mempty = ToistottomatVesat []
--  mappend (ToistottomatVesat a) (ToistottomatVesat b) = (ToistottomatVesat a) ++ (ToistottomatVesat b)

--((ToistottomatVesat a b c d e):rest) ((ToistottomatVesat a' b' c' d' e'):rest')
--tuolosta vesat = FoldMap (\(Vesa a b c d e) (Vesa a b c d e)->()) (Vesat a b c d e) mappend

--tulosta vesat = mconcat(map katto
  
--foldMap :: (Foldable f, Monoid m) => (a -> m) -> f a -> m

-- tulosta :: Vesat->String
-- tulosta vesat =
-- 
--Kuinka voin kiert‰‰ rekursion t‰ss‰?
--
--
--
--
--
--
--
--
--
--
--
