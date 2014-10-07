module problem3

let rec factorize p n = 
    if n = p then p
    else
        if n % p = 0L then factorize p (n/p)
        else factorize (p + 1L) n

let result = factorize 2L 600851475143L

printfn "%A" result