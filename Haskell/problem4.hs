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