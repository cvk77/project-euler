module Problem36

// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
// (Please note that the palindromic number, in either base, may not include leading zeros.)
//
// Answer: 872187

open System

let decToBin (n: int) = 
    Convert.ToString(n, 2)

let isPalindrome (s: string) = 
    let chars = s.ToCharArray()
    chars = Array.rev chars

let isMatch n = isPalindrome(string n) && isPalindrome(decToBin n)

let problem36 = { 1.. 999999 } |> Seq.filter isMatch |> Seq.sum