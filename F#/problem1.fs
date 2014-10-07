module problem1

let result1 = [ 1..999 ] 
                |> Seq.filter(fun x -> x % 3 = 0 || x % 5 = 0) 
                |> Seq.sum

printfn "%A" result1