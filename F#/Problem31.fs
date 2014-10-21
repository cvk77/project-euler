module Problem31

// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
// 
//     1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
// 
// It is possible to make £2 in the following way:
// 
//     1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
// 
// How many different ways can £2 be made using any number of coins?
//
// Answer: 73682

let findWays x =
    
    let denominations = [ 1; 2; 5; 10; 20; 50; 100; 200 ]

    let rec count n m =
        match n with
        | 0 -> 1
        | n when n < 0 || m < 0 && n >= 1 -> 0
        | _ -> (count n (m-1)) + (count (n-denominations.[m]) m)

    count x ((List.length denominations) - 1)
    
let result = 
    findWays 200
