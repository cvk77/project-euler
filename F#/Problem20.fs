module Problem20

// n! means n × (n − 1) × ... × 3 × 2 × 1
// 
// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
// 
// Find the sum of the digits in the number 100!
// 
// Answer: 648

open Tools

let rec digitSum n =
    match n with
    | n when n < bigint(10) -> n
    | n -> n % bigint(10) + (digitSum (n / bigint(10)))

let result = digitSum (factorial 100)

printfn "%A" result