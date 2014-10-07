module Problem3

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?
//
// Answer: 6857

let rec factorize p n = 
    if n = p then p
    else
        if n % p = 0L then factorize p (n/p)
        else factorize (p + 1L) n

let result = factorize 2L 600851475143L

printfn "%A" result