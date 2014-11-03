main :: IO()
main = print $ diff 100
	   where diff n = (3 * n^3 + 2 * n^2  - 3 * n - 2) * n `quot` 12
