problem1 :: Int
problem1 = 
	sum 
	$ filter (\x -> x `mod` 3 == 0 || x `mod` 5 == 0) 
	$ [0..999]  

main :: IO ()
main = print problem1