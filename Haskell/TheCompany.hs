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
