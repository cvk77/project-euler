from tools import factorial

#Precalculate factorials of 0..9
FACTORIAL = {}
for i in range(0, 10):
    FACTORIAL[i] = factorial(i)

UPPER_BOUND = 7 * FACTORIAL[9] + 1

s = 0
for i in xrange(10, UPPER_BOUND, 1):
    if sum(FACTORIAL[int(c)] for c in str(i)) == i:
        s += i
print s
