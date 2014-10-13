module Problem17

// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 
// (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
// 
// Answer: 21124

let words = [ 1, "one"; 2, "two"; 3, "three"; 4, "four";
5, "five"; 6, "six"; 7, "seven"; 8, "eight";
9, "nine"; 10, "ten"; 11, "eleven"; 12, "twelve";
13, "thirteen"; 14, "fourteen"; 15, "fifteen"; 16, "sixteen";
17, "seventeen"; 18, "eighteen"; 19, "nineteen"; 20, "twenty";
30, "thirty"; 40, "forty"; 50, "fifty"; 60, "sixty";
70, "seventy"; 80, "eighty"; 90, "ninety" ] |> Map.ofList

let rec n2w number =
    match words.TryFind number with
    | Some(word) -> word
    | None -> match number with
        | 0 -> ""
        | number when number < 100 -> n2w(number - number % 10) + n2w(number % 10)
        | number when number < 1000 -> 
            if number % 100 > 0 then
                n2w(number / 100) + "hundred" + "and" + n2w(number % 100)
            else
                n2w(number / 100) + "hundred"
        | number -> "onethousand"
        
let problem17 = Seq.unfold (fun state -> if state > 1000 then None 
                                         else Some((n2w state).Length, state + 1)) 1
                |> Seq.sum

