module Problem48

// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
//
// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
//
// Answer: 9110846700


let result = 

    let s = { 1I..1000I }
            |> Seq.map ( fun x -> bigint.Pow(x, int(x)) )
            |> Seq.sum
            |> string

    s.Substring(s.Length-10)




        
