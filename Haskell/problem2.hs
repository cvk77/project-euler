fibs = 0 : 1 : zipWith (+) fibs (tail fibs)

problem2 :: Int
problem2 = 
	sum
	$ filter even
	$ drop 2
	$ takeWhile (\x -> x < 4000000)
	$ fibs

main :: IO()
main = print problem2 