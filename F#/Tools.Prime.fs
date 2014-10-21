module Tools.Prime

let isPrime (num : int) =
    let number = float(num)
    if num < 2 then false
    else seq { 2.0..sqrt number } 
            |> Seq.exists (fun x -> number % x = 0.0)
            |> not

let primes = 
    let rec nextPrime n p primes =
        if primes |> Map.containsKey n then
            nextPrime (n + p) p primes
        else
            primes.Add(n, p)

    let rec prime n primes =
        seq {
            if primes |> Map.containsKey n then
                let p = primes.Item n
                yield! prime (n + 1) (nextPrime (n + p) p (primes.Remove n))
            else
                yield n
                yield! prime (n + 1) (primes.Add(n * n, n))
        }

    prime 2 Map.empty

let factors number = seq {
    for divisor = 1 to (float >> sqrt >> int) number do
    if number % divisor = 0 then
        yield divisor
        if divisor > 1 then yield number / divisor
}

let factorsCount n = factors n |> Set.ofSeq |> Set.count