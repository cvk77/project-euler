MAX = 1000000
cache = {}

def cnt(n):
    c = 1
    while n > 1:
        if n in cache:
            return c + cache[n]
        if n%2 == 0:
            n = n / 2
        else:
            n = 3 * n + 1
        c += 1
    return c
        
m, num = 0, 0

for i in xrange(1, MAX):
    l = cnt(i)
    cache[i] = l-1
    if l > m:
        m = l
        num = i

print m, num