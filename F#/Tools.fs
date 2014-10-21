module Tools

let readLines filePath = System.IO.File.ReadLines(filePath)

let digits n = 
    string n |> Seq.map(fun x -> int(x) - 48)

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

let rotate lst = List.tail lst @ [List.head lst]

let rec distribute e = function
    | [] -> [[e]]
    | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

let rec permute = function
    | [] -> [[]]
    | e::xs -> List.collect (distribute e) (permute xs)

let getRotations lst =
    let rec getAll lst i = if i = 0 then [] else lst :: (getAll (rotate lst) (i - 1))
    getAll lst (List.length lst)
    
let isPandigital (l: int list) n =
    let str = string n
    String.length str = List.length l && List.forall (fun n -> str.Contains (string n)) l