module src.tests
open Intcomp1
open week2

let e1 = Let("z", CstI 17, Prim("+", Var "z", Var "z"))

let test1Value = assemble (scomp e1 [])

let test1 = printf "%d", test1Value

let testQ1 () =
    let e1 = Let("z", CstI 17, Prim("+", Var "z", Var "z"))
    let test1Value = assemble (scomp e1 [])
    printfn "%A" (test1Value)
    ()

