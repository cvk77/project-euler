﻿module Problem24

// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation 
// of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, 
// we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
// 
// 012   021   102   120   201   210
// 
// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
// 
// Answer: 2783915460

open Tools.General
 
let fact n = [1..n] |> Seq.reduce (*)
let exclude elem = set >> Set.remove elem >> Set.toList
 
let permutation n digits =
 
    let rec permutator acc target members =
        if List.length members = 1 then
            members.[0] :: acc |> List.rev
        else
            let bucketSize = fact (members.Length) / members.Length
            let idx = target / bucketSize
            let next = members.[idx]
            permutator (next::acc) (target - bucketSize * idx) (exclude next members)
     
    permutator [] (n - 1) digits
 
let result =
    [0..9] |> permutation 1000000 
           |> Seq.fold(fun acc e -> acc + string e) ""


