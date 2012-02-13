from tools import is_prime, sieve_of_erat

LIMIT = 1000000
PRIMES   = [True] * LIMIT

def rotations(number):
    s = str(number) * 2
    for i in range(len(number)):
        yield s[i:i+len(number)]

def check_circular(number):
    if number < 10:
        return True 

    s = str(number)
    
    for c in s:
        if c not in [ '1', '3', '7', '9' ]:
            return False
   
    for j in rotations(s):
        t = int("".join(j))    
        if not PRIMES[t]:
            return False
    return True    
       
# Generate bitmap of primes
PRIMES = sieve_of_erat(LIMIT, want_bitmap=True)
       
# Check for circularity:
n = 0
for i in xrange(2, LIMIT):

    if not PRIMES[i]:
        continue
        
    if check_circular(i):
        n += 1
    
print n
