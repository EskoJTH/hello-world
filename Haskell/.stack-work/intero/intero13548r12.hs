


module Exercise where
import Prelude hiding (product)
import Data.List
import Data.Char

    --{- Deletes every character and the character -}--
findChar char [] = ""
findChar char (x:xs)  = if char == x then (xs) else findChar char (xs)
    
    --{- Deletes every character until the character -}--
dfindChar char [] = ""
dfindChar char (x:xs)  
    | length (x:xs) ==1 = if char ==x then [x] else []
    | (x:xs) == [] = []
    | otherwise = if char == x then (x:xs) else dfindChar char xs


    -- "/Kissoja.com/adkjfh2"
parseString ::[Char] -> [Char]
parseString address  
    | address == [] = []
    | findChar '/' address == "" = ""
    | otherwise = if removeAllFirst (['A'..'Z']++['a'..'z']++['.','-']) (findChar '/'address) == (dfindChar '/' (drop 1 (findChar '/' address))) then takeWhile (/='/') (findChar '/' address) else []

removeAllFirst ::[Char] -> [Char] ->[Char]
removeAllFirst targets (y:subject) 
    |targets == [] = ""
    |subject == [] = if inspect targets [y] then [] else [y]
    |otherwise = if inspect targets (y:subject) then removeAllFirst targets subject else (y:subject)

inspect :: [Char] -> [Char] -> Bool
inspect (x:targets) (y:subject) 
    |(targets) == [] = if x==y then True else False
    |length (x:targets)>0 = if x==y then True else inspect targets (y:subject)

    
dealWithIt first address
    | dfindChar '/' address == "" = address
    | (first/="")&&(drop 1 first == drop 1(dfindChar '/' first)) = parseString first
    | otherwise =  takeWhile (/='/')  address
    
takeHost :: String -> String
takeHost address = 
    let 
        first = findChar '/' address
        host = dealWithIt first (address)
    in host
