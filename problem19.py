from  datetime import date

weekday = lambda d,m,y: date(y,m,d).weekday()

l = []
for y in range(1901, 2001):
    for m in range(1,13):
        if y >= 2000:
            c = 20
        else:
            c = 19
        w = weekday(1, m, y)
        if w == 6:
            l.append((1,m,y))
print len(l)
