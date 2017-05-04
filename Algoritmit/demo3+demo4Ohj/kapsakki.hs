--k joukko.
--r kokonais paino.
--Funktio tulostaa suurimman yhteisarvon.

s :: [(Int,Int)] -> Int -> Int
s [] r = 0
s k 0 = 0
s (x:xs) r 
  |fst x>r = s xs r
  |otherwise = max (s xs r) $ snd x + s xs (r - fst x)

main :: IO()
main = do
  putStrLn $ show $ s [(1,2),(2,2),(2,3),(1,3),(1,1),(1,3)] 4
  putStrLn $ show $ s [(1,2),(2,2),(1,3),(2,2)] 1
  putStrLn $ show $ s [(1,1),(2,2),(1,3),(2,2)] 2


  
  
