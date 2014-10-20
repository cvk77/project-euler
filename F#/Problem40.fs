module Problem40

// An irrational decimal fraction is created by concatenating the positive integers:
// 
// 0.123456789101112131415161718192021...
//              ^
// 
// It can be seen that the 12th digit of the fractional part is 1.
// 
// If d_n represents the nth digit of the fractional part, find the value of the following expression.
// 
// d_1 × d_10 × d_100 × d_1000 × d_10000 × d_100000 × d_1000000
//
// Answer: 210
   
let fraction = Seq.initInfinite (fun x -> x+1) 
                |> Seq.collect string 
                |> Seq.map (fun x -> int(x) - 48)

let d n = fraction 
            |> Seq.nth (n-1)
 
let problem40 = [0..6] 
                |> Seq.map (fun n -> d (pown 10 n)) 
                |> Seq.reduce (*)
