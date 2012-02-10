from tools import divisors

is_abundant = lambda x: sum([ i for i in divisors(x) ]) > x

abundants = []

n = 0
for i in xrange(1, 28123):

    # Check if this number can be written as the sum of two abundant numbers
    b = False
    for j in abundants:
        #print "Checking %s" % j
        if i - j in abundants:
            #print "%s = %s + %s" % (i, j, i-j)
            b = True
            break

    if not b:
        print "Found match: %s" % i
        n += i

    if is_abundant(i):
        #print "Abundant: %s" % i
        
        # Cache known abundant number
        abundants.append(i)
               


print n
