from tools import num_divisors

MIN_DIVISORS = 500

num, div, tri = 0, 0, 1
while div <= MIN_DIVISORS:
    num += tri
    tri += 1
    div = num_divisors(num)

print num, div
