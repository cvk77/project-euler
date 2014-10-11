module Problem6

// The sum of the squares of the first ten natural numbers is,
// 1^2 + 2^2 + ... + 10^2 = 385
//
// The square of the sum of the first ten natural numbers is,
// (1 + 2 + ... + 10)^2 = 55^2 = 3025
//
// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
//
// Answer: 25164150

let sumOfSquares x = List.map(fun x -> pown x 2) [1..x] |> List.sum
let squareOfSum x = pown (List.sum [1..x]) 2

let problem6 = squareOfSum 100 - sumOfSquares 100

printfn "%A" problem6