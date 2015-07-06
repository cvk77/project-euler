module Problem5 where

-- 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
-- What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
--
-- Answer: 232792560

import Test.Hspec

result :: Integral a => a
result = foldr lcm 1 [1..20]

main :: IO()
main = hspec $ do 
	describe "Smallest positive number that is evenly divisible by all of the numbers from 1 to 20?" $ do
		it "should give the correct answer" $ do
			result `shouldBe` 232792560