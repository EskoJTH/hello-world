--task A
find' x [] = False
find' x (a:as)
 | a==x = True
 | otherwise = find' x as

--Käytän haskelin valmista listaa kun ei tarvitse määrittää uudelleen listan määritteleviä operaatioita.
data Lista value= Alkio {a::value, alkio :: Lista value} | Loppu {a::value} | Tyhja deriving (Show)
--task B
add' :: a->Lista a->Lista a
add' x as = case as of
  Alkio a b-> Alkio x as
  Loppu a -> Alkio x as
  Tyhja -> Loppu x

--Task C
remove' x [] = []
remove' x (a:as)
 | a==x = as
 | otherwise = a : (remove' x as)

 --Task D
union' [] ys = ys
union' (a:as) ys
 | find' a ys = union' as ys
 | otherwise = a : union' as ys

--Task E
intersection' as [] = []
intersection' [] ys = []
intersection' (a:as) ys
 | find' a ys = a : intersection' as ys
 | otherwise = intersection' as ys

   --Task F
complement' as [] = []
complement' [] ys = []
complement' as (y:ys)
 | find' y as = complement' as ys
 | otherwise = y : complement' as ys

listA=[2,3,5,6]
listB=[1,2,3,4,5]
main :: IO()
main = do
  putStrLn (show (find' 1 listA))
  putStrLn (show (remove' 2 listA))
  putStrLn (show (union' listB listA))
  putStrLn (show (intersection' listB listA))
  putStrLn (show (complement' listB listA))
  --Viimenen on aivan kamalaa koska tätä ei varmaan pitäsisi tehdä haskelissa ollenkaan näin.
  putStrLn (show (add' 3 $ add' 2 $ add' 1 Tyhja))
  
  
