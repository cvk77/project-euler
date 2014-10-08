﻿module Problem16

// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
// What is the sum of the digits of the number 2^1000?
//
// Answer: 1366

let sumOfDigits (n: bigint) = 
    string n 
        |> Seq.map(fun x -> int(x) - 48)
        |> Seq.sum

let result = sumOfDigits (bigint.Pow (bigint 2, 1000))

printfn "%A" result