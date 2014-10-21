module Problem34

// 145 is a curious number; as 1! + 4! + 5! = 1 + 24 + 120 = 145.
// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
// 
// Answer: 40730

open Tools.General

let pre_factorial n = [1; 1; 2; 6; 24; 120; 720; 5040; 40320; 362880].[n]

let isMatch n =
    n |> digits
      |> Seq.map pre_factorial 
      |> Seq.sum = n
        
let result = { 3..50000 } 
                |> Seq.filter isMatch 
                |> Seq.sum