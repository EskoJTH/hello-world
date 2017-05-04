onkoAlkio [] a = False
onkoAlkio (x:xs) a
 | x==a = True
 | otherwise = onkoAlkio xs a
 
onkoAlkio' [] n a = False
onkoAlkio' (x:[]) n a
  |x==a = True
  |otherwise = False
  
onkoAlkio' t n a = (onkoAlkio' (take halfN t) halfN a || onkoAlkio' (drop halfN t) (n-halfN) a  )
  where halfN = div n 2

main :: IO()
main = do
  putStrLn $ show $ onkoAlkio "kissa" 's'
  putStrLn $ show $ onkoAlkio' "kissa" 5 's'
  putStrLn $ show $ onkoAlkio' "porsas" 6 's'
