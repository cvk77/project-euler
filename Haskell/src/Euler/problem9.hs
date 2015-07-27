module Euler.Problem9 where

-- A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
--   a^2 + b^2 = c^2
--
-- For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
--
-- There exists exactly one Pythagorean triplet for which a + b + c = 1000.
-- Find the product abc.
--
-- Answer: 31875000

combinations :: Int -> [[Int]]
combinations n = [ [a,b,c] | y <- [2..(floor . sqrt . fromIntegral $ n)],
                             x <- [1..(y-1)],
                             let a = y^2 - x^2,
                             let b = 2*x*y,
                             let c = x^2 + y^2, a + b + c == n]

problem9 :: Int
problem9 = product $ concat (combinations 1000)

main :: IO()
main = print problem9
