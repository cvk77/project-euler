module Problem32

// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; 
// for example, the 5-digit number, 15234, is 1 through 5 pandigital.
// 
// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, 
// multiplier, and product is 1 through 9 pandigital.
// 
// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
//
// Result: 45228

open Tools.General

let isMatch n =
    let factors n = [ 2 .. (float >> sqrt >> int) n ] |> List.filter (fun i -> n % i = 0)
    let listOfDigits l = l |> List.map digits |> Seq.concat |> Seq.toList
    let isPandigital l = l |> Seq.distinct|> Seq.sort |> Seq.toList = [ 1..9 ]

    factors n
        |> List.map (fun i -> listOfDigits [n; i; n / i])
        |> List.exists isPandigital

let result = 
    { 1000 .. 10000 }
        |> Seq.filter isMatch
        |> Seq.sum
