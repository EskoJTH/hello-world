module Exercise where

deleteLast :: Eq a=>a->[a]->[a]
deleteLast a [] = []
deleteLast a (x:xs) 
    |a==x = let (results,clutter)=(deleteLastRec a (x:xs)) in results
    |otherwise = x:deleteLast a xs

deleteLastRec :: Eq a=>a->[a]->([a],Bool)
deleteLastRec a []=([],False)
deleteLastRec a (x:xs) =
    let
        (results,removed) = deleteLastRec a xs
    in 
        if ((removed==False)&&(a==x)) then (results,True) else (x:results,removed)
