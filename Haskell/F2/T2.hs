import Data.Time.Clock
import Data.Semigroup as Semi
import Data.Monoid as M
import Data.Foldable
data Vesa project subproject starttime endtime comment =
  Vesa {project:: String, subproject :: String, starttime :: UTCTime, endtime :: UTCTime, comment :: Comment} deriving (Eq,Show)
--instance Monoid (Vesa p1 p2 start end com) where
--  mempty = Vesa [] [] (UTCTime 0)(UTCTime 0) (Comment [])
--  mappend (Vesa p1 p2 start end com)  (Vesa p1' p2' start' end' com') = 
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
  
newtype TimeSpan a b = TimeSpan {getTime :: (UTCTime,UTCTime)} deriving (Eq,Show,Ord)
instance Semigroup (TimeSpan a b) where
  (<>) (TimeSpan (a,b)) (TimeSpan (c,d)) = TimeSpan(min a c, max b d)
  
newtype Comment = Comment {getComment :: String} deriving (Eq,Show,Ord)
instance Monoid Comment  where
  mempty = Comment []
  mappend (Comment a) (Comment b) = Comment (a ++ " " ++ b)
  
data Vesat a = Vesat {a ::[Vesa String String UTCTime UTCTime Comment]} deriving (Eq,Show)
instance Monoid (Vesat a) where
  mempty = Vesat []
  mappend (Vesat a) (Vesat b) = Vesat (a ++ b)

jarjesta :: [Vesa String String UTCTime UTCTime Comment] ->[[Vesa String String UTCTime UTCTime Comment]]
jarjesta vesat = groupBy (\(Vesa a b c d e) ((Vesa a' b' c' d' e'):vesas)->if(a==(a'))then True else False) (sortWith (\(Vesa a b c d e)->a) vesat) 

--Timespan ja kommentti löytyy tästä.
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
--
