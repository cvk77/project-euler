module Problem47

// The first two consecutive numbers to have two distinct prime factors are:
// 
// 14 = 2 × 7
// 15 = 3 × 5
// 
// The first three consecutive numbers to have three distinct prime factors are:
// 
// 644 = 2² × 7 × 23
// 645 = 3 × 5 × 43
// 646 = 2 × 17 × 19.
// 
// Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
// 
// Answer: 134043

open Tools.Prime
 
let result =

    Seq.initInfinite (fun s -> s+1) 
        |> Seq.filter (fun n -> factorsCount n = 4) 
        |> Seq.windowed 4
        |> Seq.filter (fun l -> Seq.max (l) - Seq.min (l) = 3)
        |> Seq.head
        |> Seq.head