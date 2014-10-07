module Tools

let isPrime (num : int) =
    let number = float(num)
    if num < 2 then false
    else seq { 2.0..sqrt number } 
            |> Seq.exists (fun x -> number % x = 0.0)
            |> not