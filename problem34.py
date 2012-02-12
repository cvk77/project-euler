from tools import factorial

#Precalculate factorials of 0..9
UPPER_BOUND = 7 * factorial(9) + 1

s = 0
for i in xrange(10, UPPER_BOUND, 1):
    if sum(factorial(int(c)) for c in str(i)) == i:
        s += i
print s
