module Problem35

// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
// 
// How many circular primes are there below one million?
// 
// Answer: 55

open Tools.General
open Tools.Prime

let isCircularPrime n =
    n   |> digits |> Seq.toList 
        |> getRotations
        |> List.map (Seq.reduce (fun acc elem -> elem + acc * 10))
        |> List.forall isPrime

let result = primes 
                |> Seq.takeWhile (fun n -> n < 1000000) 
                |> Seq.filter isCircularPrime 
                |> Seq.length
