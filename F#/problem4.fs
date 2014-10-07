module Problem4

// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.
//
// Answer: 906609

let isPalindrome number =
    let numberAsString = string(number)
    let length = numberAsString.Length
    List.forall (fun i -> numberAsString.[i] = numberAsString.[length-1-i]) [0..length-1]

let pairs = seq { 
    for x in [100..999] do
        for y in [100..x] do 
            yield x,y 
        }

let palindromes = pairs 
                    |> Seq.map(fun (x,y) -> x*y)
                    |> Seq.filter(isPalindrome) 
                    |> Seq.max

printfn "%A" palindromes