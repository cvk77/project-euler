g, s, a, y = 1, 24, 52, 3

while y <= 1001:
    g += s
    s += a
    a += 32
    y += 2

print g
