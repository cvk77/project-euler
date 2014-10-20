module Problem36

// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
// (Please note that the palindromic number, in either base, may not include leading zeros.)
//
// Answer: 872187

open Tools

let decToBin n =
    let rec f n acc =
        match n with
        | 0 -> acc
        | n -> f (n >>> 1) ((n &&& 1) :: acc)
    f n []   

let isPalindrome list = 
    list = List.rev list

let isMatch n = isPalindrome(List.ofSeq (digits n)) && isPalindrome(decToBin n)

let problem36 = { 1 .. 999999 } 
                |> Seq.filter isMatch 
                |> Seq.sum