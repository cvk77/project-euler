module Problem51

// By replacing the 1st digit of the 2-digit number *3, it turns out that six of 
// the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
// 
// By replacing the 3rd and 4th digits of 56**3 with the same digit, 
// this 5-digit number is the first example having seven primes among the ten 
// generated numbers, yielding the family: 
// 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, 
// being the first member of this family, is the smallest prime with this property.
// 
// Find the smallest prime which, by replacing part of the number (not necessarily 
// adjacent digits) with the same digit, is part of an eight prime value family.
//
// Answer: 121313

open Tools.Prime
open Tools.General
open System

let of3Digits0To2 (s: string) =
    let counts = [| (s.Split('0').Length - 1);
                    (s.Split('1').Length - 1);
                    (s.Split('2').Length - 1); |]
    if counts.[1] = 3 && s.Substring(5) = "1" then false
    else counts.[0] >= 3 || counts.[1] >= 3 || counts.[2] >= 3
 
let has7Transforms (s: string) =
    let variant =
        if s.Split('0').Length - 1 >= 3 then
           ("0",["1";"2";"3";"4";"5";"6";"7";"8";"9"])
        elif s.Split('1').Length - 1 >= 3 then
           ("1",["0";"2";"3";"4";"5";"6";"7";"8";"9"])
        else
           ("2",["0";"1";"3";"4";"5";"6";"7";"8";"9"])
 
    Seq.length
        (seq {
            for i in (snd variant) do
                let candidate = Int32.Parse(s.Replace((fst variant), i))
                if isPrime candidate && candidate >= 100000 then
                    yield candidate
              }) >= 7

let candidates =
    primes
    |> Seq.takeWhile ((>) 1000000)
    |> Seq.filter ((<) 100000)
    |> Seq.map string
    |> Seq.filter of3Digits0To2
 
let result =
    candidates
    |> Seq.find has7Transforms
    |> int

