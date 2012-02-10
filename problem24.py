import itertools
    
f = itertools.permutations(range(10))

for i in range(1000000):
    s = f.next()

print "".join(map(str, s))
