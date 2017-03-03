module Exercise where
import Data.List
import Data.Word                    -- .. different lengths of integers
import Data.Char (ord,chr)          -- .. conversion between char and int

encode :: String -> [(Char,Word8)]  -- You can convert an Int to Word8 with 
                                    -- function fromIntegral. 
encode []=[]
encode (x:xs) =
    encodeLoop x 0 (x:xs)

encodeLoop :: Char -> Int -> String -> [(Char,Word8)]
encodeLoop letter count [] =[(letter, fromIntegral count)] 
encodeLoop letter count (x:xs) 
    |(count==255)=(letter, fromIntegral count):(encodeLoop x 1 xs)
    |letter==x = encodeLoop letter (count+1) xs
    |otherwise = (letter, fromIntegral count):(encodeLoop x 1 xs)

decode :: [(Char,Word8)] -> String
decode [] = []
decode ((letter,count):xs) = (replicate (fromIntegral count) letter ) ++ decode xs 
