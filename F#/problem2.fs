module problem2

let fib = Seq.unfold (fun (a,b) -> Some( a+b, (b, a+b) ) ) (0,1)
let result = fib 
                |> Seq.takeWhile(fun x -> x < 4000000) 
                |> Seq.filter(fun x -> x % 2 = 0) 
                |> Seq.sum

printfn "%A" result