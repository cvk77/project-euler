module Problem9

// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, 
//   a^2 + b^2 = c^2
// 
// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
// 
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.
// 
// Answer: 31875000

let isTriplet a b c = pown a 2 + pown b 2 = pown c 2

let triplets = seq {
    for x in [ 1..1000 ] do
        for y in [x+1..1000] do
            let z = 1000 - x - y
            if (isTriplet x y z) then yield x*y*z
}

let result = triplets |> Seq.exactlyOne

printfn "%A" result