module Euler.Problem5 where

-- 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
-- What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
--
-- Answer: 232792560

problem5 :: Int
problem5 = foldr lcm 1 [1..20]

main :: IO()
main = print problem5 
