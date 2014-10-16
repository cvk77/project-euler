module Problem33

// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may 
// incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
// 
// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
// 
// There are exactly four non-trivial examples of this type of fraction, less than one in value, and 
// containing two digits in the numerator and denominator.
// 
// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
//
// Solution: 100
   
open Tools

let candidates = 
    seq {
        for i = 10 to 99 do
            for j = i+1 to 99 do
                yield i, j
    }

let commonDigits n d = Set.intersect (Set.ofSeq (digits n)) (Set.ofSeq (digits d)) |> Set.filter (fun n -> n > 0)
let fakeEliminate x y = int("0" + string(x).Replace(string(y), ""))

let isCuriousFraction (n,d) = 
    commonDigits n d
        |> Set.map (fun x -> float(n) / float(d) = float(fakeEliminate n x) / float(fakeEliminate d x))
        |> Set.contains true

let problem33 = 
    let solution = candidates
                    |> Seq.filter isCuriousFraction
                    |> Seq.reduce (fun acc (n,d) -> (fst acc * n, snd acc * d) )
    snd solution / fst solution
            