module Problem50

// The prime 41, can be written as the sum of six consecutive primes:
// 41 = 2 + 3 + 5 + 7 + 11 + 13
// 
// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
// 
// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
// 
// Which prime, below one-million, can be written as the sum of the most consecutive primes?
//
// Answer: 997651
   
open Tools.Prime

let primes = { 2 .. 3931 } |> Seq.filter isPrime |> Seq.cache

let getPrimeSequence n =
        primes
        |> Seq.filter (fun x -> x > n)
        |> Seq.scan (fun (sum, count) x -> (sum + x, count + 1)) (n, 1)
        |> Seq.filter (fun (sum, count) -> isPrime sum)
        |> Seq.maxBy (fun (sum, count) -> count)
 
let result = primes 
                |> Seq.map getPrimeSequence 
                |> Seq.maxBy (fun (sum, count) -> count)
                |> fst
