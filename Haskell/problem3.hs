factorize :: Int -> Int -> Int
factorize p n =
	if n == p then p
	else 	
		if n `mod` p == 0 then factorize p (n `quot` p)
		else factorize (p + 1) n

problem3 :: Int
problem3 = factorize 2 600851475143

main :: IO()
main = print problem3