from tools import divisors
is_abundant = lambda x: sum([ i for i in divisors(x) ]) > x

LIMIT = 28100

known_abundant = [False] * LIMIT
sums = range(0,LIMIT)

# Find all abundant numbers
for i in xrange(12, LIMIT):
    
    if not known_abundant[i]:
        
        # Not already known abundant, let's check
        if is_abundant(i):
            known_abundant[i] = True
        
            # All multiples are abundant too:
            for j in xrange(i, LIMIT, i):
                known_abundant[j] = True
 
# Sieve out all abundants that can be written as the sum of two abundants
for i in xrange(1, LIMIT / 2):
    if known_abundant[i]:
        for j in xrange(i, LIMIT - i):
            if known_abundant[j]:
                sums[i+j] = 0
        
print sum(sums)


