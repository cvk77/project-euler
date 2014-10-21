module Problem41

// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
// For example, 2143 is a 4-digit pandigital and is also prime.
// 
// What is the largest n-digit pandigital prime that exists?
// Answer: 7652413

open Tools.General
open Tools.Prime
 
let result = { 1..7 } 
                |> Seq.collect (fun m -> [1..m] |> permute)
                |> Seq.map (Seq.reduce (fun acc elem -> elem + acc * 10))
                |> Seq.filter isPrime
                |> Seq.max
