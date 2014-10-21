module Problem10

// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
// Find the sum of all the primes below two million.
//
// Answer: 142913828922

open Tools.Prime

let result = {1..2000000}
                |> Seq.filter isPrime
                |> Seq.map int64
                |> Seq.sum

