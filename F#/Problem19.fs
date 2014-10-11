module Problem19

// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
//
// Answer: 171

let weekday day month year = 
    
    let gauss d m c y = int(d + int(2.6 * (float m) - 0.2) + y + int(floor(float(y)/4.0)) + int(floor(float(c)/4.0)) - 2 * c) % 7
    
    let splitYear year = 
        let y = if month < 3 then year-1 else year
        int(y / 100), y % 100
    
    let c, y = splitYear year
    gauss day ((month + 9) % 12 + 1) c y

let daysToCheck = Seq.unfold(fun state -> 
    if state = 12 * 100 then None 
    else Some(weekday 1 (state % 12 + 1) (1901 + state / 12), state+1)) 0  
        
let result = daysToCheck 
                |> Seq.filter (fun dow -> dow = 0)
                |> Seq.length

printfn "%A" result