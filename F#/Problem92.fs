module Problem92

// A number chain is created by continuously adding the square of the digits in a number to form a new number until it has been seen before.
// 
// For example,
// 
// 44 → 32 → 13 → 10 → 1 → 1
// 85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
// 
// Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.
// 
// How many starting numbers below ten million will arrive at 89?
//
// Answer: 8581146

open Tools.General

let step x = 
    let rec step' sum dividend =
        if dividend = 0 then sum
        else 
            let rem = dividend % 10
            step' (sum + rem * rem) (dividend / 10)
    step' 0 x

let prepareChains =
    let cache : int array = Array.create 568 0
    cache.[1] <- 1
    cache.[89] <- 89
    
    let rec arrivesAt start =
        match cache.[start] with
        | 0 -> 
            let temp = step start |> arrivesAt
            cache.[start] <- temp
            temp
        | x -> x
    
    for i = 1 to 567 do 
        arrivesAt i |> ignore

    cache
 
let result = 
    let terminals = prepareChains
    { 1..9999999 }
        |> Seq.sumBy (fun n -> if terminals.[step n] = 89 then 1 else 0)
