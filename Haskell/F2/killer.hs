main = do fk
fk = ask >>= isK
ask = putStrLn "Are you the killer?(y/n)" >> getLine

isK s = case yn s of
  Left a -> a
  Right a -> a >>= writeFile "killer.txt" --got 'em
  
yn s = case s of
  "y" -> Right $ putStrLn "Enter your ip" >> getLine
  "n" -> Left $ putStrLn "Good day to you!"
  _ -> Left fk
