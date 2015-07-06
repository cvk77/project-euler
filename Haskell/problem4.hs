module Problem4 where

-- A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
-- Find the largest palindrome made from the product of two 3-digit numbers.
--
-- Answer: 906609

isPalindromic :: Int -> Bool
isPalindromic b = 
	x == (reverse x)
	where 
		x = show b

problem4 = 
	maximum
	$ filter isPalindromic
	$ [ i * j | i <- [100 .. 999], j <- [i .. 999] ]

main :: IO()
main = print problem4