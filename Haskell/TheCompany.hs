module TheCompany where

data SummerEmployee = SummerEmployee {payChecInformation :: PayChecInformation
                                     ,sandwichesSold :: Int}
                                   deriving (Eq,Show,Ord)

data PayChecInformation = PayChecInformation {bankAccount :: String
                                             ,localAddress :: String
                                             ,city :: City
                                             ,postalNumber :: Int
                                             ,country :: Country}
                        deriving (Eq,Show,Ord)

data Country = Country String deriving(Eq,Ord,Show)

data City = City String deriving(Eq,Ord,Show)


data Booth = Booth {location :: String
                            ,phone :: Int}

data Protocolla = Protocolla String

data Salutation = Salutation String


data OsaanTehdaMontaKonstruktoriaSamaanTyyppiin = Osaan
  |Tehda
  |Monta Konstruktoria
  |Samaan
  |Tyyppiin deriving (Eq, Show)

type Osaan = Bool
type Tehda = IO()
type Monta = Maybe Int
type Konstruktoria = String
type Samaan = Bool
type Tyyppiin = String

osaanMyosKayttaaNaita :: OsaanTehdaMontaKonstruktoriaSamaanTyyppiin->String
osaanMyosKayttaaNaita Osaan = "ehka" 
osaanMyosKayttaaNaita Tehda = "kai" 
osaanMyosKayttaaNaita Samaan = "juu!?" 
osaanMyosKayttaaNaita Tyyppiin = "Aikalailla" 
osaanMyosKayttaaNaita _ = "eiko niin?"

osaanko :: OsaanTehdaMontaKonstruktoriaSamaanTyyppiin
osaanko = Samaan

tosi :: Samaan
tosi = True

main :: IO()
main = do
   let text = osaanMyosKayttaaNaita osaanko
   putStrLn text
