module Tools.General

let readLines filePath = System.IO.File.ReadLines(filePath)

let contains number list = Seq.exists (fun elem -> elem = number) list

let crossproduct l1 l2 = seq { for x in l1 do
                                   for y in l2 do
                                       yield x, y }

let digits n = string n |> Seq.map(fun x -> int(x) - 48)

let digitsList n = digits n |> List.ofSeq

let implodeDigits l = l |> Seq.fold (fun acc elem -> (int64 elem) + acc * 10L) 0L

let factorial (n:int): bigint = [bigint(1) .. bigint(n)] |> List.fold (*) bigint.One

let (!>) f (a,b) = f a b

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
    
let isPandigital l= 
    l |> Set.ofList |> Set.count = List.length l

let rec fillList len item list = 
    if List.length list >= len then list
    else fillList len item (item :: list)

let fillZeros len list = fillList len 0 list
