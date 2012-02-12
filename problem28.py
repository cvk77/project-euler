LIMIT = 1001

s = 1
for y in range(3, LIMIT+1, 2):
    for n in range(4):
        s += y ** 2 - n * (y - 1)

print s
