#!/usr/bin/env stack
-- stack --resolver lts-9.6 script --package megaparsec --package text

-- NOTE. To run this file (Expr.hs), do
-- chmod +x Expr.hs
-- echo "3*(12+x)" | ./Expr.hs


{-#LANGUAGE TypeFamilies#-}
{-#LANGUAGE OverloadedStrings#-}
import Text.Megaparsec.Expr
import Text.Megaparsec
import Text.Megaparsec.Char
import qualified Text.Megaparsec.Lexer as L
import Data.Text (Text)
import qualified Data.Text.IO as TIO
import Data.Void

main = do
        input <- TIO.getContents
        case runParser (expr<*optional eol<*eof) "stdin" input of
            Left err -> putStrLn (parseErrorPretty err)
            Right v  -> print (calculate v)

calculate = id -- COMPLETE THIS

expr :: Parsec Dec Text Expression

expr = makeExprParser term table <?> "expression"

parens = between (char '(') (char ')')

term = parens expr <|> (Var <$> letterChar) <|> (Lit <$> L.decimal) <?> "term"

data Expression = Lit Integer
                | Var Char
                | Negate Expression 
                | Add Expression Expression
                | Sub Expression Expression
                | Mul Expression Expression
                | Div Expression Expression
                deriving (Eq,Show,Ord)


table = [ [ prefix  "-"  Negate
          , prefix  "+"  id ]
        , [ binary  "*"  Mul
          , binary  "/"  Div  ]
        , [ binary  "+"  Add
          , binary  "-"  Sub  ] ]

sym n = string n <* space

binary  name f = InfixL  (f <$ sym name)
prefix  name f = Prefix  (f <$ sym name)
postfix name f = Postfix (f <$ sym name)
