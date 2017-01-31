module Schanfinkeling where

schanfinkeling :: ((a,b)->c)->a->b->c
schanfinkeling f x y = f (x, y)

unSchanfinkeling :: (a->b->c)->(a,b)->c
unSchanfinkeling f (x, y) = f x y

