is_triplet = lambda a,b,c: a*a + b*b == c*c

# Quite naive approach, yay for computing power
for a in range(1,1000):
    for b in range(a,1000-a):
        for c in range(b,1000-b):
            if a+b+c == 1000:
                if is_triplet(a,b,c):
                    print a,b,c
                    print a*b*c