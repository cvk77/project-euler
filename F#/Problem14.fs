﻿module Problem14

// The following iterative sequence is defined for the set of positive integers:
// 
// n → n/2 (n is even)
// n → 3n + 1 (n is odd)
// 
// Using the rule above and starting with 13, we generate the following sequence:
// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
// 
// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
// Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
// 
// Which starting number, under one million, produces the longest chain?
// 
// NOTE: Once the chain starts the terms are allowed to go above one million.
// 
// Answer: 837799

open System.Collections.Generic

let cache (f: int64 -> 'a) =

    let dict = new Dictionary<int64, 'a>()

    let cached (input: int64) =
        if dict.ContainsKey input then dict.Item(input)
        else 
            let answer = f input
            dict.Add (input, answer)
            answer
    
    cached
    
let rec row =
    cache (function
            | 1L -> 1
            | n when n % 2L = 1L -> 1 + (row (3L*n+1L))
            | n -> 1 + row(n/2L)
          )
 
let problem14 = { 1L..1000000L } 
                |> Seq.maxBy row

printfn "%A" problem14