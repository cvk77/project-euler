﻿module Problem2

// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
//
// Answer: 4613732

let fib = Seq.unfold (fun (a,b) -> Some( a+b, (b, a+b) ) ) (0,1)
let problem2 = fib 
                |> Seq.takeWhile(fun x -> x < 4000000) 
                |> Seq.filter(fun x -> x % 2 = 0) 
                |> Seq.sum

printfn "%A" problem2