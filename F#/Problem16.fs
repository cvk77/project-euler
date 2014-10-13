module Problem16

// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
// What is the sum of the digits of the number 2^1000?
//
// Answer: 1366

open Tools

let sumOfDigits (n: bigint) = 
    n |> digits |> Seq.sum

let problem16 = sumOfDigits (bigint.Pow (bigint 2, 1000))

