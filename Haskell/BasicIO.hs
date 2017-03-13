main = do
  --Do block starts here
  
    --IO operation
    putStr   "Pick a natural number less than 10,"
    --IO operation
    putStrLn "and I'll try to guess what it is!"
    
    --The let portion is inside the do block but IO actions don't calculate iside it

    --Portion that defines something inside a let block type of loop is told uder this line
    let loop :: Int -> Int -> IO ()
        loop a b 
         | a==b      = putStrLn ("The number is "++show a) -- not an IO operation yet. Happens only once it is called in a lazy manner from an IO block
         | otherwise = do
                        -- Another do block
             
                        --another let block type of try is Int
                        let try = (a + b) `div` 2

                        --IO operation
                        putStrLn ("Is it more than "
                                 ++ show try
                                 ++ " ? (True/False)")
                        --IO output gets assigned type IO ()
                        isGreater <- getLine
                        
                        --IF block
                        if (read isGreater)
                             --type IO ()
                             then loop (try + 1) b
                             --type IO ()
                             else loop a       try
                                  
                        -- Another do block ends
    --funktion call type IO ()
    loop 1 10
    --IO operation type IO ()
    putStrLn "Thanks for playing"
    --Do block ends here
