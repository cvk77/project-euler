module ResultsSpec where

import Euler.Problem1  (problem1)
import Euler.Problem2  (problem2)
import Euler.Problem3  (problem3)
import Euler.Problem4  (problem4)
import Euler.Problem5  (problem5)
import Euler.Problem6  (problem6)
import Euler.Problem7  (problem7)
import Euler.Problem8  (problem8)
import Euler.Problem9  (problem9)

import Test.Hspec


spec :: Spec
spec = do
    describe "Problem 1" $ do
        it "should find the sum of all the multiples of 3 or 5 below 1000" $ do
            problem1 `shouldBe` 233168
    describe "Problem 2" $ do
        it "should find the sum of the even-valued terms below 4 million" $ do
            problem2 `shouldBe` 4613732
    describe "Problem 3" $ do
        it "should find the largest prime factor of the number 600851475143" $ do
            problem3 `shouldBe` 6857
    describe "Problem 4" $ do
        it "should find the largest palindrome made from the product of two 3-digit numbers" $ do
            problem4 `shouldBe` 906609
    describe "Problem 5" $ do
        it "should give the smallest positive number that is evenly divisible by all of the numbers from 1 to 20" $ do
            problem5 `shouldBe` 232792560
    describe "Problem6" $ do
        it "should find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum" $ do
            problem6 `shouldBe` 25164150
    describe "Problem7" $ do
        it "should find the the 10001st prime number" $ do
            problem7 `shouldBe` 104743
    describe "Problem8" $ do
        it "should find the greatest product of the thirteen adjacent digits in the 1000-digit" $ do
            problem8 `shouldBe` 23514624000
    describe "Problem9" $ do
        it "should find the product of the only Pythagorean triplet with a + b + c = 1000" $ do
            problem9 `shouldBe` 31875000
