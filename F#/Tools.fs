﻿module Tools

let readLines filePath = System.IO.File.ReadLines(filePath)

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

let factorial (n:int): bigint = [bigint(1) .. bigint(n)] |> List.fold (*) bigint.One

