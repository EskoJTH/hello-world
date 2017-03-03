module Exercise where

delete :: (Eq a) => a -> [a] ->[a]
delete a [] = []
delete a (x:xs)
    |a==x = xs
    |otherwise = x:(delete a xs)

takeEvens :: Integral a => [a]->[a]
takeEvens [] = []
takeEvens (x:xs) 
    |even x = x:(takeEvens xs)
    |otherwise =takeEvens xs

(+++) :: [a]->[a]->[a]
(+++) list1 list2 = list1++list2

myConcat :: [[a]]->[a]
myConcat [] = []
myConcat (x:xs) = x +++ myConcat xs
