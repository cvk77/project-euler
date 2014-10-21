module Problem46

// It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
// 
// 9 = 7 + 2×12
// 15 = 7 + 2×22
// 21 = 3 + 2×32
// 25 = 7 + 2×32
// 27 = 19 + 2×22
// 33 = 31 + 2×12
// 
// It turns out that the conjecture was false.
// 
// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
//
// Answer: 5777
   
open Tools.Prime

let result =
    let oddComposites = Seq.unfold (fun s -> Some(s, s+2)) 3
                        |> Seq.filter (fun n -> not(isPrime n))

    let twiceSquares n = Seq.unfold (fun s -> if s >= n then None else Some(2 * pown s 2, s+1)) 1

    let isMatch n = twiceSquares n
                    |> Seq.exists (fun x -> isPrime (n - x)) 

    oddComposites |> Seq.find (fun x -> not(isMatch x))