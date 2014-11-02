module Problem92

// A number chain is created by continuously adding the square of the digits in a number to form a new number until it has been seen before.
// 
// For example,
// 
// 44 → 32 → 13 → 10 → 1 → 1
// 85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
// 
// Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.
// 
// How many starting numbers below ten million will arrive at 89?

open Tools.General

let cache = ref Map.empty

let memoize f =
    fun x ->
        match (!cache).TryFind(x) with
        | Some res -> res
        | None -> let res = f x
                  cache := (!cache).Add(x,res)
                  res

let rec digits b x = 
    seq { 
        if x <> 0 then 
            yield! digits b (x/b)
            yield x % b
        }

let step = digits 10 >> Seq.sumBy (fun x -> x*x) |> memoize

let rec chain n = 
    if n = 1 || n = 89 then n
    else memoize chain (step n)

let result = 
    { 1..9999999 }
        |> Seq.filter (fun n -> (chain n) = 89) 
        |> Seq.length
