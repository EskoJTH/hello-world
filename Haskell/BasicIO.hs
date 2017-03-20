main = do
  --Do block starts here
  
    --IO operation
    putStr   "Pick a natural number less than 10,"
    --IO operation
    putStrLn "and I'll try to guess what it is!"

    --a let block that defines a funktion called "loop" starts here
    --The let portion is inside the do block but IO actions aren't executed iside it
    let loop :: Int -> Int -> IO ()
        loop a b 
         | a==b      = putStrLn ("The number is "++show a) -- this is an IO operation that gets executed later once it is called from a do block.
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
