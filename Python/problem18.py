f = open("data/triangle18.txt", "r")
data=[[int(x) for x in line.split(' ')] for line in f]
f.close()

print reduce(lambda s, line: map(max, 
    zip(
        map(lambda x: x[0]+x[1], zip(s, line)), 
        map(lambda x: x[0]+x[1], zip(s[1:], line))
    )
), data[::-1])[0]
