﻿module Problem22

// Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, 
// is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
// What is the total of all the name scores in the file?
// 
// Answer: 871198282

open Tools.General

let removeQuotes s = string(s).Replace("\"", "")

let calculateScore index (name: string) = 
    let charValue c = int(c) - int('A') + 1
    Seq.sumBy charValue name * (index + 1)
    
let result = (readLines "names.txt" |> Seq.head).Split ',' |> Array.map removeQuotes
                |> Array.sort
                |> Array.mapi calculateScore
                |> Array.sum

