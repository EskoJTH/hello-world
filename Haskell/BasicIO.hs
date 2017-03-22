
main = do
  --Do block starts here
  
    --plain action --IO operation
    putStr   "Pick a natural number less than 10," :: IO ()
    --plain action --IO operation
    putStrLn "and I'll try to guess what it is!" :: IO ()

    --a let block that defines a funktion called "loop" starts here
    --Bind --The let portion is inside the do block but IO actions aren't executed iside it
    let loop :: Int -> Int -> IO ()
        loop a b 
         | a==b      = putStrLn ("The number is "++show a) -- this is an IO operation that gets executed later once it is called from a do block.
         | otherwise = do
                        -- Another do block
             
                        --Bind --another let block type of try is Int
                        let try = (a + b) `div` 2 :: Int

                        --plain action --IO operation
                        putStrLn ("Is it more than "
                                 ++ (show try :: String)
                                 ++ (" ? (True/False)")::String) :: IO ()
                        --pure bind --IO action output (String) gets assigned to isGreater
                        
                        isGreater <- getLine :: IO String --isGreater is String
                        
                        --plain action --IF block
                        if (read isGreater)
                             --Bind--IO action
                             then loop (try + 1) b
                             --Bind--IO action
                             else loop a       try         
                        -- the second do block ends
                        
    --Bind --funktion call that returns type IO () and then that gets executed
    loop 1 10
    --Plain action --IO operation that writes a String to Console
    putStrLn "Thanks for playing" :: IO ()
    --Do block ends here
