module week2
open Intcomp1

// Exercises 2.4 2.5

// Our function. Matches an instruction to its corresponding list
let sinstrToInt (s : sinstr) : int list = 
    match s with
    | SCstI i -> [0; i]
    | SVar i -> [1; i]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]
    
// Our function. Assembles the complete list of instructions to integers.
let assemble (sl : sinstr list) : int list = List.collect sinstrToInt sl

// Our function. Compares an expression to stack instructions and puts it into a file
let sinstrComp (e : expr) = scomp e [] |> assemble |> intsToFile

