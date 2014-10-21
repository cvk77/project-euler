module Problem28

// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
// 
// 21 22 23 24 25
// 20  7  8  9 10
// 19  6  1  2 11
// 18  5  4  3 12
// 17 16 15 14 13
// 
// It can be verified that the sum of the numbers on the diagonals is 101.
// 
// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
//
// Answer: 669171001

open Tools

let result = 
    
    let diagonalSums y = 
        Seq.unfold (fun state -> 
            if (state > 3) then None 
            else Some((pown y 2) - state * (y - 1), state + 1)) 0 
        |> Seq.sum
    
    Seq.unfold (fun state -> 
        if (state > 1001) then None 
        else Some(diagonalSums state, state + 2)) 3
        |> Seq.sum
        |> add 1
