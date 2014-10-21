module Problem37

// The number 3797 has an interesting property. Being prime itself, it is possible to continuously 
// remove digits from left to right, and remain prime at each stage: 
// 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
//
// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
// 
// Answer: 748317

open Tools.Prime

let truncate n = 
    
    let truncateRight n = n / 10

    let truncateLeft n = n % pown 10 ((float >> log10 >> int) n)

    let rec loop (f: int -> int) n acc = 
        match n with 
        | 0 -> acc
        | n -> loop f (n |> f) (n :: acc)

    [] 
        |> loop truncateLeft n
        |> loop truncateRight n
        |> Seq.distinct
        
let isMatch n = 
    n 
        |> truncate
        |> Seq.forall isPrime

let result = { 23..2..739397 } |> Seq.filter isMatch |> Seq.sum