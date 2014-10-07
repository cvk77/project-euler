module problem7

// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?
//
// Answer: 104743

let isPrime (num : int) =
    let number = float(num)
    if num < 2 then false
    else seq { 2.0..sqrt number } 
            |> Seq.exists (fun x -> number % x = 0.0)
            |> not

let primes = Seq.initInfinite (fun i -> i) 
                |> Seq.filter isPrime
    
let result = primes 
                |> Seq.take 10001
                |> Seq.last
    
printfn "%A" result