import Data.Foldable
data Solmu value = Solmu {dat::value, sup :: Solmu value }| Empty deriving (Show)

initializeTRIE :: [[a]] -> [[Solmu a]]
initializeTRIE [] = []
--initializeTRIE (set:sets) = (fold (\x xs -> Solmu x (xs 0)) (const Empty) set ): (initializeTRIE sets)
initializeTRIE (set:sets) = g (foldr f e set) : (initializeTRIE sets)
  where
    g :: (Solmu b -> a) -> a
    g h = h Empty
    f x acc k = (Solmu x k) : acc (Solmu x k)
    e = (const [])

buildLeg [] sup = []
buildLeg (s:set) sup =
  Solmu (dat s) (sup s) : buildLeg set (Solmu (dat s) (sup s))


union (a:setA) (b:setB) 
  | a==b = a : (union setA setB)
  | otherwise = a: Solmu (dat b) (sup b) : buildLeg setB (Solmu (dat b) (sup b))

syote = ["banaani", "luumu", "omena", "persikka", "sitruuna"]
main :: IO()
main = do
  putStrLn (show (initializeTRIE syote))
