module week2
open Intcomp1

let sinstrToInt (s : sinstr) : int list = 
    match s with
    | SCstI i -> [0; i]
    | SVar i -> [1; i]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]
    
let assemble (sl : sinstr list) : int list = List.collect sinstrToInt sl

let sinstrComp (e : expr) = scomp e [] |> assemble