




module SeasonalTime where
import Data.Time.Clock


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
    season t = toGregorian
    season t = case urgh of
        ... -> Winter
    season Mar = 
    season Apr = 
    season May = 
    season Jun = 
    season Jul = 
    season Aug = 
    season Sep = 
    season Oct = 
    season Nov = 
    season Dec = 

  --Olen yritt‰nyt saada t‰m‰n vekottimen toimimaan varmaan 3 tuntia ja patterna matchata eri UTCTimet eri  vuodenaikoihin, mutta ei toimi ei sitten mill‰‰n ei mit‰‰n hajua miten t‰t‰ utc time‰ voi k‰ytt‰‰.
  
