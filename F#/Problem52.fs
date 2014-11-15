module Problem52

// It can be seen that the number, 125874, and its double, 251748, 
// contain exactly the same digits, but in a different order.
//
// Find the smallest positive integer, x, such that 
// 2x, 3x, 4x, 5x, and 6x, contain the same digits.
//
// Answer: 142857

let isAnagram x y = 

    let sortString s = 
        s |> string |> Array.ofSeq
          |> Array.sort

    let s1 = sortString x
    let s2 = sortString y
     
    if Array.length s1 <> Array.length s2 then
        false
    else
        Array.forall2 (fun x y -> x = y) s1 s2
            
let result =
    Seq.initInfinite (fun n -> n+1)
    |> Seq.find (fun n ->
        [2..6] |> List.map (fun x -> x * n)
               |> List.forall (fun xn -> isAnagram xn n)
    )
