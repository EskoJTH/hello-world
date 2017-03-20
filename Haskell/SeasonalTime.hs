module SeasonalTime where
import Data.Time.Clock
import Data.Time.Calendar


data Season = Winter | Spring | Summer | Autumn deriving Show
data Month  = Jan | Feb | Mar | Apr | May | Jun 
            | Jul | Aug | Sep | Oct | Nov | Dec deriving (Show,Eq,Ord)

class Seasonal a where
    season :: a -> Season

instance Seasonal Month where
    season Dec = Winter
    season Jan = Winter
    season Feb = Winter
    season Mar = Spring
    season Apr = Spring
    season May = Spring
    season Jun = Summer
    season Jul = Summer
    season Aug = Summer
    season Sep = Autumn
    season Oct = Autumn
    season Nov = Autumn
    
data Event = MayDay | IndependenceDay | MothersDay

instance Seasonal Event where
     season IndependenceDay = Winter
     season MothersDay = Spring
     season MayDay = Spring
  
instance Seasonal UTCTime where
    season t = let (_,x,_) = toGregorian (utctDay t) in
      case x of
     12 -> Winter
     1 -> Winter
     2 -> Winter
     3 -> Spring
     4 -> Spring
     5 -> Spring
     6 -> Summer
     7 -> Summer
     8 -> Summer
     9 -> Autumn
     10 -> Autumn
     11 -> Autumn

--Osasimpas, mutta olipa vaikeaa kesiä.

main :: IO()
main = getCurrentTime >>= putSeasonalTime

putSeasonalTime :: Seasonal a => a -> IO ()
putSeasonalTime time = case season time of
  Winter -> putStrLn "Talvi"
  Spring -> putStrLn "Kevat"
  Summer -> putStrLn "Kesa"
  Autumn -> putStrLn "Syksy"


  
