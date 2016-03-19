 //Sulyagina Anastasia (c) 2014
//Expressions

type Expr = 
    | Const of int
    | Var of string
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

    
let rec calc expr =
    match expr with
        | Add (Const x, Const y) -> Const (x + y)
        | Sub (Const x, Const y) -> Const (x - y)
        | Mul (Const x, Const y) -> Const (x * y)
        | Div (Const x, Const y) -> Const (x / y)
        | Add (x, Const 0) | Add (Const 0, x) | Sub (x, Const 0) -> x
        | Mul (x, Const 1) | Mul (Const 1, x) | Div (x, Const 1) -> x
        | Mul (x, Const 0) | Mul (Const 0, x) | Div (0, x) -> Const 0
        | Sub (Var x, Var y) -> if x = y then Const 0
                                else expr
        | Add (x, y) -> Add (calc x , calc y)
        | Sub (x, y) -> Sub (calc x , calc y)
        | Mul (x, y) -> Mul (calc x , calc y)
        | Div (x, y) -> Div (calc x , calc y)
        | _ -> expr
 
 
let exp = calc (Add (Const 5, Add (Const 5, Const 5)))
printfn "%A" exp
