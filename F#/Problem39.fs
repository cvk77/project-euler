module Problem39

// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
// 
// {20,48,52}, {24,45,51}, {30,40,50}
// 
// For which value of p ≤ 1000, is the number of solutions maximised?
//
// Answer: 840

let calc p =
    
    let calc a = 
        let b = p * (a-p/2.0) / (a - p)
        let c = (-(pown a 2) + p * a - (pown p 2) / 2.0) / (a - p)
        a, b, c

    [ 1.0 .. p / 2.0 ]
        |> Seq.map calc
        |> Seq.filter (fun (a,b,c) -> b % 1.0 = 0.0 && c % 1.0 = 0.0)
        |> Seq.length
        
let result = 
    [2.0 .. 1000.0]
        |> List.maxBy calc
