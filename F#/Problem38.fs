module Problem38

// Take the number 192 and multiply it by each of 1, 2, and 3:
// 
//     192 × 1 = 192
//     192 × 2 = 384
//     192 × 3 = 576
// 
// By concatenating each product we get the 1 to 9 pandigital, 192384576. 
// We will call 192384576 the concatenated product of 192 and (1,2,3)
// 
// The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, 
// giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
// 
// What is the largest 1 to 9 pandigital 9-digit number that can be formed as the 
// concatenated product of an integer with (1,2, ... , n) where n > 1?
//
// Answer: 932718654

let createProduct x =
    let rec loop n acc =
        match acc with
        | acc when String.length acc >= 9 -> acc
        | acc -> loop (n+x) (acc + string n)

    loop x ""

let result = 
    let isPandigital (str:string) = String.length str = 9 && [1..9] |> List.forall (fun n -> str.Contains (string n))
    { 1..100000 }
    |> Seq.map createProduct 
    |> Seq.filter isPandigital
    |> Seq.max