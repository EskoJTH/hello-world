module JsonConversion where
import Data.Text
import Data.List

class Show a => JSON a where
  toJSONString :: a -> String

--instance (Show a, Num a) => JSON a where ---------miksi t�ss� on joku hemmetin virhe....
  --toJSONString int = ('\"':show int ++ "\" ")

instance JSON Int where
  toJSONString int = ('\"':show int ++ "\" ")

instance JSON Integer where
  toJSONString int = (convertInt int)
  --(("\"Int :" ++).((show int) ++ "\""))
  
convertInt :: Integer -> String
convertInt int = ('\"':show int ++ "\" ")
--convertInt int = "\"Int\": " ++ ('\"':show int ++ "\" ")

instance JSON Char where
  toJSONString char = show( char:"")

instance JSON Text where
  toJSONString text = (convertText text)
  
convertText :: Text -> String
convertText text = ((show text)++ " ")
--convertText text = "\"text\": " ++ ((show text)++ " ")
  
instance JSON a => JSON [a] where
  toJSONString list = "[" ++ Prelude.concat (Data.List.intersperse "," (Prelude.map toJSONString list)) ++ "]"
--"\"list\": " ++ ('\"': (Prelude.foldr (++) [] (Prelude.map (toJSONString) list)) ++ ( "}" ))

instance (JSON a, JSON b, JSON c) => JSON (a,b,c) where
  toJSONString (a,b,c) = "{\"fst\": " ++ (( toJSONString a ++ (", \"Sec\": " ++(( toJSONString b ++(", \"Thr\": " ++ toJSONString c ++ " }"))))))
    
instance (JSON a, JSON b) => JSON (a,b) where
  toJSONString (a,b) = "{\"fst\": " ++ ((( toJSONString a  ++(", \"Scd\": " ++ toJSONString b ++ " }"))))

main :: IO ()
main = do
  let text = toJSONString (pack "kissa")
  putStrLn text
  let text = toJSONString (12::Int,(pack "kissa"),2::Int)
  putStrLn text
  let text = toJSONString ((pack"kissa"),pack "laatikko")
  putStrLn text
  let text = toJSONString [pack "ki",pack "ss",pack "a"]
  putStrLn text
  let text = toJSONString ([1,2,3]::[Int],[(pack "cat",(6::Int,'a')),(pack "dog",(7::Int,'x'))])
  putStrLn text
  
