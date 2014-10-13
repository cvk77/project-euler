module Tools

let readLines filePath = System.IO.File.ReadLines(filePath)

let isPrime (num : int) =
    let number = float(num)
    if num < 2 then false
    else seq { 2.0..sqrt number } 
            |> Seq.exists (fun x -> number % x = 0.0)
            |> not

let factors number = seq {
    for divisor = 1 to (float >> sqrt >> int) number do
    if number % divisor = 0 then
        yield divisor
        if divisor > 1 then yield number / divisor
}

let factorial (n:int): bigint = [bigint(1) .. bigint(n)] |> List.fold (*) bigint.One

let add x y = x + y

let maxIndex seq =
    seq |> Seq.mapi (fun i x -> i, x)
        |> Seq.maxBy snd 
        |> fst

let rec comb n l = 
    match n, l with
    | 0, _ -> [[]]
    | _, [] -> []
    | k, (x::xs) -> List.map ((@) [x]) (comb (k-1) xs) @ comb k xs