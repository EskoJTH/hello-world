import Data.Time.Clock
data Vesa = Vesa {project:: String, subproject :: String, starttime :: UTCTime, endtime :: UTCTime, comment :: String} deriving (Eq,Show)
