sqrt = lambda x: x ** .5

def is_prime(x):
    if x == 1:
        return True
    if x == 2:
        return True
    if x % 2 == 0:
        return False
    
    for i in range(3, x/2+1, 2):
        if x % i == 0:
            return False
    return True
    
def num_divisors(n):
    t = 0
    for factor in range(1, int(sqrt(n))+1):
        if n % factor == 0: t += 2
    return t
    
def divisors(n):
    for factor in range(1, n / 2 + 1):
        if n % factor == 0: yield factor
    
def factorial(n):
    if n < 2:
        return n
    return reduce(lambda x, y: x * y, range(2, n+1))
