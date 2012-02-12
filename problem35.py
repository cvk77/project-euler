from tools import is_prime
from itertools import permutations

LIMIT = 1000000
NUM_PRIMES = LIMIT
PRIMES   = [True] * NUM_PRIMES
CIRCULAR = [False] * NUM_PRIMES

def rotations(number):
    s = str(number) * 2
    for i in range(len(number)):
        yield s[i:i+len(number)]

# Generate primes between 1 and LIMIT
for i in xrange(2, NUM_PRIMES):
    for j in xrange(i*2, LIMIT, i):
        PRIMES[j] = False

def check_circular(number):
    # Check if all rotations are primes
    for j in rotations(str(number)):
        t = int("".join(j))    
        if not PRIMES[t]:
            return False
    return True    
      
# Check for circularity:
for i in xrange(2, LIMIT):

    if not PRIMES[i] or CIRCULAR[i]:
        continue
        
    if check_circular(i):
        CIRCULAR[i] = True
    
r = [ i for (i,j) in enumerate(CIRCULAR) if j ]
print len(r)
