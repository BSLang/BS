module BS.AST

type Expr = 
    | String of string

type Statement = 
    | Echo of Expr