module Problem26

// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
// 
//     1/2	= 	0.5
//     1/3	= 	0.(3)
//     1/4	= 	0.25
//     1/5	= 	0.2
//     1/6	= 	0.1(6)
//     1/7	= 	0.(142857)
//     1/8	= 	0.125
//     1/9	= 	0.(1)
//     1/10	= 	0.1
// 
// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
// 
// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
//
// Answer: 983

open Tools.General

let recurringCycleLength n =
    
    let rec loop a b curmap acc =
        if a % b = 0 then 0
        else
            match Map.tryFind a curmap with
            | Some(pos) -> acc - (Map.find a curmap)
            | _ -> loop (a % b * 10) b (curmap.Add(a, acc)) (acc+1)

    loop 1 n Map.empty 0
 
let result = {1..999} 
                    |> Seq.map recurringCycleLength
                    |> maxIndex |> (+) 1
            
