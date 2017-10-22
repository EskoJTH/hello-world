module V6T3 where
{-
Use

data Fix f = Fix (f (Fix f))

instead of explicit recursion to implement the following types.

    data List a = Nil | Cons a (List a)
    data Tree a = Leaf a | Branch (Tree a) (Tree a)
    data Pair a b = Pair a b
-}

--data List a = Nil | Cons a (List a)

data Fix f = Fix (f (Fix f))

data Id a = Id a
data ListF a = Nil | Cons a (Fix ListF)

data ListF' a = ListF' (Fix Help) a
data Help r a  = Nil' | Cons' a r

--data ListFix a = Nil | Cons a deriving Show

test1 = Nil
test2 = Cons 1 $ Fix Nil
test3 :: ListF Int
test3 = Cons 1 $ Fix $ Cons (2::Int) $ Fix $ Cons 3 $ Fix Nil

--data ListF a = ListF (Fix ListFix)
--data ListF a = ListF (Fix a)
--data ListF = ListF (Fix ListFix Int)
--data ListF a = ListF (Fix (ListFix a))
--data ListFix recu = Nil | Cons Int (recu Int)
--testList1 = ListF $ Fix Nil
--testist2 :: Fix (ListFix Int)
--testLIst2 = ListF $ Fix Nil
--testList3 = ListF $ Fix (Cons (Fix (Const _ _)) (Nil))
--test2 = Cons 2 Nil
--test3 = Cons 1 $ Cons 3 $ Cons 2 Nil
