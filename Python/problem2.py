def fib(n):
    yield 1
    x,y = 0,1
    while y < n:
        x,y = y,x+y
        yield y

print (sum([ x for x in fib(4000000) if x % 2 == 0 ]))
