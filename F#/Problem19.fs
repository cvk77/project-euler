module Problem19

// You are given the following information, but you may prefer to do some research for yourself.
// 
//     1 Jan 1900 was a Monday.
//     Thirty days has September,
//     April, June and November.
//     All the rest have thirty-one,
//     Saving February alone,
//     Which has twenty-eight, rain or shine.
//     And on leap years, twenty-nine.
//     A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
// 
// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
//
// Answer: 171

let isLeapYear year = year % 4 = 0 && (year % 100 <> 0 || year % 400 = 0)

let yearLength year = if isLeapYear year then 366 else 365

let monthLength month year = 
    match month with
    | 4 | 6 | 9 | 11 -> 30
    | 2 when isLeapYear year -> 29
    | 2 -> 28
    | _ -> 31

let firstDayOfMonth month year =
    let mutable days = 0
    for y  = 1900 to year-1 do
        days <- days + yearLength y
    for m = 1 to month-1 do
        days <- days + monthLength m year
    days % 7
    
let isFirstDayASunday month year = firstDayOfMonth month year = 6

let mutable result = 0

for year = 1901 to 2000 do
    for month = 1 to 12 do
        if isFirstDayASunday month year then 
                result <- result + 1

printfn "%A" result
