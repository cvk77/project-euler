from tools import fib

f = fib()

i = 0
while 1:
    i += 1
    n = f.next()
    if len(str(n)) >= 1000:
        print i, n
        break
