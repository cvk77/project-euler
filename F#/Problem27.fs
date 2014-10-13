module Problem27

// Euler discovered the remarkable quadratic formula:
// 
// n² + n + 41
// 
// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
// However, when n = 40, 40² + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when 
// n = 41, 41² + 41 + 41 is clearly divisible by 41.
// 
// The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the 
// consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.
// 
// Considering quadratics of the form:
// 
//     n² + an + b, where |a| < 1000 and |b| < 1000
// 
//     where |n| is the modulus/absolute value of n
//     e.g. |11| = 11 and |−4| = 4
// 
// Find the product of the coefficients, a and b, for the quadratic expression that produces 
// the maximum number of primes for consecutive values of n, starting with n = 0.
//
// Answer: -59231

open Tools

let findConsecutivePrimes a b =
    let quadraticFormula = fun n -> (pown n 2) + a * n + b
    let rec findNonPrime n = 
        if isPrime (quadraticFormula n) then findNonPrime (n+1)
        else n
    findNonPrime 1

let problem27 = comb 2 [-999..999]
                |> Seq.map (fun x -> findConsecutivePrimes x.[0] x.[1], x.[0] * x.[1])
                |> Seq.max
                |> snd

printfn "%A" problem27
