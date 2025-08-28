(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

//module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)]

let emptyenv = [](* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr
  
type aexpr =
    | CstI2 of int
    | Var2 of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr

let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

(* our expression *)
let e4 = Prim("min", CstI 3, CstI 7)
let e5 = Prim("min", CstI 7, CstI 3)
let e6 = Prim("max", CstI 3, CstI 7)
let e7 = Prim("max", CstI 7, CstI 3)
let e8 = Prim("==", CstI 3, CstI 7)
let e9 = Prim("==", CstI 7, CstI 7)
let e10 = If(Var "a", CstI 11, CstI 22)

// expressions for 1.2
let e11 = Sub (Var2 "v", Add (Var2 "w", Var2 "z"))
let e12 = Mul (CstI2 2, e11)
let e13 = Add (Var2 "x", Add (Var2 "y", Add (Var2 "z", Var2 "v")))
let e14 =
    Add(
        Add (CstI2 0, Var2 "x"),                  // 0 + e  -> e
        Add(
            Add (Var2 "y", CstI2 0),              // e + 0  -> e
            Add(
                Sub (Var2 "z", CstI2 0),          // e - 0  -> e
                Add(
                    Mul (CstI2 1, Var2 "u"),      // 1 * e  -> e
                    Add(
                        Mul (Var2 "v", CstI2 1),  // e * 1  -> e
                        Add(
                            Mul (CstI2 0, Var2 "w"),  // 0 * e -> 0
                            Add(
                                Mul (Var2 "k", CstI2 0), // e * 0 -> 0
                                Sub (Var2 "p", Var2 "p") // e - e -> 0
                            )
                        )
                    )
                )
            )
        )
    )
let e15 = Add (CstI2 0, CstI2 1)

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim (ope, e1, e2) ->
        let a = eval e1 env
        let b = eval e2 env
        match ope with
        | "+" -> a+b 
        | "*" -> a*b 
        | "-" -> a-b
        | "min" -> if a < b then a else b
        | "max" -> if a > b then a else b
        | "==" -> if a = b then 1 else 0
        | _ -> failwith "unknown operator"
    | If(e1, e2, e3) ->
        let cond = eval e1 env <> 0
        let e2 = eval e2 env
        let e3 = eval e3 env
        if cond then e2 else e3

let rec fmt (a:aexpr) =
    match a with
    | CstI2 i -> string i
    | Var2 s -> s
    | Add(a1, a2) -> fmt a1 + " + " + fmt a2
    | Mul(a1, a2) -> fmt a1 + " * " + fmt a2
    | Sub(a1, a2) -> fmt a1 + " - " + fmt a2
    
let rec simplify (a:aexpr) =
    match a with
    | CstI2 i -> CstI2 i
    | Var2 s -> Var2 s
    | Add(a1, a2) ->
        let a1 = simplify a1
        let a2 = simplify a2
        if a1 = CstI2 0 then simplify a2
        else if a2 = CstI2 0 then simplify a1
        else Add (a1, a2)
    | Mul(a1, a2) ->
        let a1 = simplify a1
        let a2 = simplify a2
        if a1 = CstI2 0 then CstI2 0
        else if a2 = CstI2 0 then CstI2 0
        elif a1 = CstI2 1 then simplify a2
        else if a2 = CstI2 1 then simplify a1
        else Mul (a1, a2)
    | Sub(a1, a2) ->
        let a1 = simplify a1
        let a2 = simplify a2
        if a1 = CstI2 0 then simplify a2
        else if a2 = CstI2 0 then simplify a1
        elif a1 = a2 then CstI2 0
        else Sub (a1, a2)

let rec symdiff (a:aexpr) (v:string) =
    match a with
    | CstI2 _ -> CstI2 0
    | Var2 s -> if s = v then CstI2 1 else CstI2 0
    | Add(a1, a2) -> Add(symdiff a1 v, symdiff a2 v)
    | Mul(a1, a2) -> Add(Mul (symdiff a1 v, a2), Mul (symdiff a2 v, a1))
    | Sub(a1, a2) -> Sub(symdiff a1 v, symdiff a2 v)

let e1v  = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [("a", 314)]
let e3v  = eval e3 env

(* example expressions 1.1 ii*)
let e4v = eval e4 env
let e5v = eval e5 env
let e6v = eval e6 env
let e7v = eval e7 env
let e8v = eval e8 env
let e9v = eval e9 env
let e10v = eval e10 env

let e14simp = simplify e14
let e15simp = simplify e15
let e16sym = symdiff e12 "v"