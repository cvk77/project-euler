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
    if n <= 1:
        return 1
    return reduce(lambda x, y: x * y, range(2, n+1))
    
def fib():
    a, b = 1, 1
    yield 1
    while 1:
        yield a
        a, b = a + b, a
        
def sieve_of_erat(end, want_bitmap=False):  
    if end < 2: return []  
    lng = ((end/2)-1+end%2)     
    sieve = [True]*(lng+1)  
    for i in range(int(sqrt(end)) >> 1):  
        if not sieve[i]: continue  
        for j in range( (i*(i + 3) << 1) + 3, lng, (i << 1) + 3):  
            sieve[j] = False  

    if want_bitmap:
        primes = [0, False, True] + [ False ] * (end - 2)
        for i in range(lng):
            primes[(i << 1) + 3] = sieve[i]
    else:
        primes = [2]  
        primes.extend([(i << 1) + 3 for i in range(lng) if sieve[i]])  

    return primes
