import math
from tools import is_prime
    
x = 600851475143
y = int(math.sqrt(x))+1
while y > 1:
    if x % y == 0 and is_prime(y):
        print y
        break
    y = y - 1
