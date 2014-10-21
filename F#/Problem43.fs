module Problem43

// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
// 
// Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
// 
//     d2d3d4=406 is divisible by 2
//     d3d4d5=063 is divisible by 3
//     d4d5d6=635 is divisible by 5
//     d5d6d7=357 is divisible by 7
//     d6d7d8=572 is divisible by 11
//     d7d8d9=728 is divisible by 13
//     d8d9d10=289 is divisible by 17
// 
// Find the sum of all 0 to 9 pandigital numbers with this property.
//
// Answer: 16695334890

open Tools.General
   
let genfirst d = [d..d..999] 
                 |> List.map (int64 >> digitsList >> (fillZeros 3)) 
                 |> List.filter isPandigital

let gennext d l = [ for lst in l do
                        for i in [0..9] do
                            let cons = i :: lst
                            if isPandigital cons then
                                match lst with
                                | h :: hh :: tail when (i * 100 + h*10 + hh) % d = 0 -> yield cons
                                | _ -> () 
                  ]

let result = genfirst 17
                |> gennext 13
                |> gennext 11
                |> gennext 7
                |> gennext 5
                |> gennext 3
                |> gennext 2
                |> gennext 1
                |> List.map implodeDigits
                |> List.sum