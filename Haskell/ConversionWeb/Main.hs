{-# LANGUAGE OverloadedStrings #-}
import Web.Scotty
import Data.Text.Lazy
import Data.Char
import Data.List
--Anna nettisivu tyyliin http://localhost:3000/Ihanmitavaan/1EURUSD  -- /convert/15?to=usd&from=eur. /:home:/:arguments
countries = Data.List.words "USD EUR GBP INR AUD CAD ZAR NZD JPY"
usd =[("USD",1.00000) ,("EUR",0.92012) ,("GBP",0.79425) ,("INR",65.0717) ,("AUD",1.30957) ,("CAD",1.33416) ,("ZAR",12.5760) ,("NZD",1.41715) ,("JPY",110.296)]
usdi = Data.List.words "1.00000 1.08681 1.25905 0.01537 0.76361 0.7495 0.07952 0.70564 0.00907"

main = scotty 3000 $ do
  get "/convert/:amount" $ do
     amount <- param "amount"
     to <- param "to"
     from <- param "from"
     let
          palaute = relation (read amount) (Prelude.map Data.Char.toUpper from) (Prelude.map Data.Char.toUpper to)
     html $ mconcat ["<h1>", pack amount, " ",pack from , ". Muutetaan valuutta: ",pack palaute , " ",pack to, "</h1>"]

relation :: Double -> String -> String -> String
relation amount from to =
  let
    (firstCountry,fstMult) = fstCountry from usd
    (secondCountry,sndMult) = fstCountry to usd
  in
     case (firstCountry,secondCountry) of
        ([],_) -> show 0 
        (_,[]) -> show 0
        (_,_) -> show (amount * ((realToFrac sndMult) / (realToFrac fstMult)))

fstCountry :: Fractional a => String -> [(String, a)] -> (String,a)
fstCountry _ [] = ([],0)
fstCountry text ((country,value):countries) = case Data.List.isInfixOf country text of
  True -> (country,value)
  False -> fstCountry text countries


------------- Ei tarvita loppuja.







     
--kasittele :: String -> String
--kasittele text = show (read (Prelude.takeWhile isNumber (Prelude.map Data.Char.toUpper text)) * relation (Prelude.map Data.Char.toUpper (Prelude.dropWhile isNumber text)))

--Minkä ihmeen takia en löydä tätä funktiota valmiina mistään. Eihän tämän koodaamisessa alusta lähtien ole mitään jäkeä.
--Eikö kukaan ennen minua ole ajateellut että joskus stringistä pitää poistaa ensimmäinen ilmentymä toisesta stringistä?
--Vai johtuuko tämä vaan siitä että minun oikeasti pitäisi käyttää jotain taulukoita tai Text:tejä
--Mitähän minä mietin kun tämänkin tein. Enhän minä tätä edes tarvitse.
removeFirstSubstring substring text = remFstSub substring substring text

remfstSub :: String->String->String->String
remfstSub _ _ [] = []
remFstSub (y:ys) (x:xs) (t:ts)
 |x==t =
  let
    (readyText,success) = remNextSub (y:ys) (t:ts)
  in
    if success then readyText else t : remFstSub (y:ys) (x:xs) ts
 |otherwise = t : remFstSub (y:ys) (x:xs) ts

remNextSub :: String -> String -> (String,Bool)
remNextSub [] text = (text,True)
remNextSub _ [] = ([],False)
remNextSub (x:xs) (t:ts)
  | x==t = remNextSub xs ts
  | otherwise = ([],False)

--toimi :: Data.Text.Internal.Lazy.Text->Data.Text.Internal.Lazy.Text->ActionM ()
--toimi arguments action = case action of
  --pack "convert" -> html $ mconcat ["<h1>Scotty, ", arguments, " me up!</h1>"]
 -- _ -> html $ mconcat ["<h1>Shotty me up!</h1>"]
 -- /convert/15?to=usd&from=eur.
    
--1 USD EUR GBP INR AUD CAD ZAR NZD JPY
--1.00000 0.92012	0.79425	65.0717	1.30957	1.33416	12.5760	1.41715	110.296
--Inverse:	
--1.00000 1.08681	1.25905	0.01537	0.76361	0.74954	0.07952	0.70564	0.00907


-- 1x = 1.5y
-- 1/1.5 x = 1.5y
