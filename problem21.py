from tools import divisors

candidates = range(1, 10001)

n = 0
while candidates:
    a = candidates.pop(0)
    b = sum([_ for _ in divisors(a)])
    if b in candidates: candidates.remove(b)
    if a != b and a == sum([_ for _ in divisors(b)]):
        n += a + b

print n