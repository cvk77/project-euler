LIMIT = 28123

# Generate abundants
L = dict.fromkeys(xrange(1, LIMIT+1), 0) 
for i in L:
    for j in [ i * n for n in xrange(1, LIMIT / i + 1) ]:
        if i != j: 
            L[j] += i
abundants = [ i for i in L if L[i] > i ]

# Generate sums of two abundant numbers
sums = set()
for i in abundants:
    for j in abundants:
        if not i + j in sums:
            sums.add(i + j)
        
solution = [ i for i in xrange(LIMIT) if i not in sums ]
        
print sum(solution)
