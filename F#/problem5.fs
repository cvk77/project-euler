module Problem5

// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
//
// Answer: 232792560

let rec gcd x y = 
    if y = 0L then x 
    else gcd y (x % y)

let lcm x y = x * y / (gcd x y)

let problem5 = [1L..20L] 
                |> Seq.fold lcm 1L

