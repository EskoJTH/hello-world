module JsonConversion where
import Data.Text
import Data.List

class Show a => JSON a where
  toJSONString :: a -> String

instance JSON Int where
  toJSONString int = ('\"':show int ++ "\" ")

instance JSON Integer where
  toJSONString int = (convertInt int)
  --(("\"Int :" ++).((show int) ++ "\""))
  
convertInt :: Integer -> String
convertInt int = ('\"':show int ++ "\" ")
--convertInt int = "\"Int\": " ++ ('\"':show int ++ "\" ")

instance JSON Text where
  toJSONString text = (convertText text)
  
convertText :: Text -> String
convertText text = ((show text)++ " ")
--convertText text = "\"text\": " ++ ((show text)++ " ")
  
instance JSON a => JSON [a] where
  toJSONString list = "[" ++ Prelude.concat (Data.List.intersperse "," (Prelude.map toJSONString list)) ++ "]"
--"\"list\": " ++ ('\"': (Prelude.foldr (++) [] (Prelude.map (toJSONString) list)) ++ ( "}" ))
    
instance (JSON a, JSON b) => JSON (a,b) where
  toJSONString (a,b) = "{\"fst\": " ++ ((( toJSONString a  ++(", \"Scd\": " ++ toJSONString b ++ " }"))))

instance (JSON a, JSON b, JSON c) => JSON (a,b,c) where
  toJSONString (a,b,c) = "{\"fst\": " ++ (( toJSONString a ++ (", \"Sec\": " ++(( toJSONString b ++(", \"Thr\": " ++ toJSONString c ++ " }"))))))



main :: IO ()
main = do
  let text = toJSONString (pack "kissa")
  putStrLn text
  let text = toJSONString (1::Int,(pack"kissa"),2::Int)
  putStrLn text
  let text = toJSONString ((pack"kissa"),pack "laatikko")
  putStrLn text
  let text = toJSONString [pack "ki",pack "ss",pack "a"]
  putStrLn text
  
