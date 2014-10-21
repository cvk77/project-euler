module Problem42

// The nth term of the sequence of triangle numbers is given by, t_n = ½n(n+1); so the first ten triangle numbers are:
// 
// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
// 
// By converting each letter in a word to a number corresponding to its alphabetical position and adding these 
// values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t_10. 
// If the word value is a triangle number then we shall call the word a triangle word.
// 
// Using words.txt, a 16K text file containing nearly two-thousand common English words, how many are triangle words?
//
// Answer: 162

open Tools

let removeQuotes s = string(s).Replace("\"", "")
let wordValue s = Seq.sumBy (fun c -> int c - int 'A' + 1) s
let contains number list = List.exists (fun elem -> elem = number) list

let result = 
    let words = (readLines "words.txt" |> Seq.head).Split ',' |> Array.map removeQuotes
    let scores = words |> Array.map wordValue 
    let triangleNumbers =  Seq.initInfinite (fun n -> let d = float n
                                                      int((d / 2.0) * (d + 1.0)))  
    let relevantTriangleNumbers = triangleNumbers |> Seq.takeWhile (fun n -> n <= Array.max scores) |> List.ofSeq

    scores 
        |> Array.filter (fun score -> relevantTriangleNumbers |> contains score)
        |> Array.length
                    
