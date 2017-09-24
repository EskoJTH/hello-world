{-
    x
    |
  +---+
  | f'|
  +---+
   |  \ 
   |   |
  f x  "f was called."

let (y,s) = g' x
    (z,t) = f' y in (z,s++t)
                    
     x
     |
   +---+
   | g'|
   +---+
    |   \   
  +---+  | "g was called."
  | f'|  |
  +---+  |
   | \   |
   |  \  |
   |  +----+
   |  | ++ |
   |  +----+
   |     |
f (g x) "g was called.f was called."

bind f' :: (Float,String) -> (Float,String)

bind :: (Float -> (Float,String)) -> ((Float,String) -> (Float,String))


-}

bind :: (Float -> (Float,String)) -> ((Float,String) -> (Float,String))
bind f' (gx,gs) = let
  (fx,fs) = f' gx in
  (fx, gs ++ fs)

lift f x = (f x,"")
(*) f' g' = bind f' . g'
{-
lift f * lift g = lift (f.g)
\x->(f x,"") * \y->(g y,"") = (f g, "")
\x->(f x,"") * \y->(g y,"") = (f g, "")
bind \x->(f x,"") . \y->(g y,"") = (f g, "")

-}
