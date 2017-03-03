module SeasonalTime where


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

    
