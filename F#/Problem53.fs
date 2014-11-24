module Problem53

// There are exactly ten ways of selecting three from five, 12345:
// 
// 123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
// 
// In combinatorics, we use the notation, 5_C_3 = 10.
// 
// In general,
// n_C_r = n! / r!(n−r)! where r ≤ n
// 
// It is not until n = 23, that a value exceeds one-million: 23_C_10 = 1144066.
// 
// How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?
//
// Answer: 4075

open Tools.General
   
let C n r = (factorial n) / ((factorial r) * factorial(n-r))

let result = 
    [ for n in 23..100 do for r in 1..n do yield (n,r) ]
    |> Seq.filter(fun (n,r) -> C n r > (bigint 1000000))
    |> Seq.length
    
                