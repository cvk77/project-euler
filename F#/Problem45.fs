﻿module Problem45

// Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
// Triangle 	  	T_n=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
// Pentagonal 	  	P_n=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
// Hexagonal 	  	H_n=n(2n−1) 	  	1, 6, 15, 28, 45, ...
// 
// It can be verified that T_285 = P_165 = H_143 = 40755.
// 
// Find the next triangle number that is also pentagonal and hexagonal.
//
// Answer: 1533776805

let result =
    
    let H n = n * (2 * n - 1)
    let hexagonals = Seq.initInfinite H
    let isMatch n = ((sqrt (float n * 24.0 + 1.0) + 1.0) / 6.0) % 1.0 = 0.0

    hexagonals 
        |> Seq.skip 144
        |> Seq.find isMatch
