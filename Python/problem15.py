def pascal(n):
    l, p = [1], []
    for i in xrange(n):
        l2 = [1]
        for j in xrange(len(l)-1):
            l2.append(l[j]+l[j+1])
        l2.append(1)
        l=l2
    return l

WIDTH = 20
    
print pascal(WIDTH * 2)[WIDTH]
