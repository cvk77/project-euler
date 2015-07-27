module Euler.Problem6 where

-- The sum of the squares of the first ten natural numbers is,
-- 1^2 + 2^2 + ... + 10^2 = 385
-- 
-- The square of the sum of the first ten natural numbers is,
-- (1 + 2 + ... + 10)^2 = 55^2 = 3025
-- 
-- Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
-- Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
-- 
-- Answer: 25164150

problem6 :: Int
problem6 = diff 100
    where diff n = (3 * n^3 + 2 * n^2  - 3 * n - 2) * n `quot` 12

main :: IO()
main = print problem6
