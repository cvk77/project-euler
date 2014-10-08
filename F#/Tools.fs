module Tools

let isPrime (num : int) =
    let number = float(num)
    if num < 2 then false
    else seq { 2.0..sqrt number } 
            |> Seq.exists (fun x -> number % x = 0.0)
            |> not

let factors number = seq {
    for divisor in 1 .. (float >> sqrt >> int) number do
    if number % divisor = 0 then
        yield divisor
        yield number / divisor
}

let rec factorial (n: int) : bigint =
    match n with  
    | 1 -> bigint(1)  
    | n -> bigint(n) * factorial(n - 1) 