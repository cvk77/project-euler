module Problem7

// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?
//
// Answer: 104743

open Tools

let primes = Seq.initInfinite (fun i -> i) 
                |> Seq.filter isPrime
    
let problem7 = primes 
                |> Seq.take 10001
                |> Seq.last
    
printfn "%A" problem7