﻿module Problem15

// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
// How many such routes are there through a 20×20 grid?
//
// Answer: 137846528820

open Tools.General

let routes n = factorial (2 * n) / (factorial(n) * factorial(n))
let result = routes 20

