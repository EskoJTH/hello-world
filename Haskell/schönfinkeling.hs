module Schanfinkeling where

schanfinkeling f x y = f (x, y)

unSchanfinkeling f (x, y) = f x y