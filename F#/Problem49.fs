module Problem49

// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
//  (i)  each of the three terms are prime, and, 
//  (ii) each of the 4-digit numbers are permutations of one another.
//
// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, 
// but there is one other 4-digit increasing sequence.
//
// What 12-digit number do you form by concatenating the three terms in this sequence?
//
// Answer: 296962999629

open Tools.General
open Tools.Prime

let result = 

    let fourDigitPrimes = { 1000..9999 } |> Seq.filter isPrime
    let getPermutations n = ((digits n) |> Seq.toList |> permute ) |> Seq.map (implodeDigits >> int)

    let isMatch n = 
        let primePerms = getPermutations n |> Seq.filter isPrime
        primePerms |> contains (n + 3330) && 
        primePerms |> contains (n + 6660)

    fourDigitPrimes 
        |> Seq.skipWhile (fun n -> n < 1488)
        |> Seq.find isMatch
        |> fun x -> sprintf "%d%d%d" x (x+3330) (x+6660)

             
                
