module TheCompany where
type SummerWorker = (Name,PaymentInformation,SandwichesSold)
type Name = String
type SandwichesSold = Integer
type PaymentInformation = (Country, City, Street, SocialSecurityNumber, ETC)
type Street = String
type SocialSecurityNumber = String
type ETC = String
type Country = String
type City = String

main :: IO()
main = do
  let text = createStuff elisa
  putStrLn text
  let text = createStuff' (12345,Just 0441234567)
  putStrLn text

createStuff :: SummerWorker -> String
createStuff worker = case worker of
  ("Elisa", _,_) -> "Hommissa on Elisa."
  (_,_,_) -> "Hommissa on joku, mutta ei ainakaan Elisa."
  
createStuff' :: Booth -> String
createStuff' worker = case worker of
  (_,Nothing) -> "Tyhja koppi on."
  (_,_) -> "Joku on kopissa!"

payInfo :: PaymentInformation
payInfo = (suomi,kuopio,tulliportinkatu,numero,jotain)

suomi :: Country
suomi = "Suomi"

kuopio :: City
kuopio = "Kuopio"

tulliportinkatu :: Street
tulliportinkatu = "Tulliportinkatu"

numero :: SocialSecurityNumber
numero = "222J"

jotain :: ETC
jotain = "Osaa ihmisasioita ja on kai nainen"

sandWichesSold :: Integer
sandWichesSold = 2

elisa :: SummerWorker
elisa = ("Elisa", payInfo, sandWichesSold)

type Booth = (Coordinates, PhoneNumber)
type Coordinates = Integer
type PhoneNumber = Maybe Integer

type NettiWebbiOsote = Maybe String

type Salutation = Maybe SomethingLikeAKnight
type SomethingLikeAKnight = String
