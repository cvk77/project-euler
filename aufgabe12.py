MIN_DIVISORS = 500

sqrt = lambda x: x ** .5

def divisors(n):
    t = 0
    for factor in range(1, int(sqrt(n))+1):
        if n % factor == 0: t += 2
    return t

num, div, tri = 0, 0, 1
while div <= MIN_DIVISORS:
    num += tri
    tri += 1
    div = divisors(num)

print num, div
