factorial = lambda n: reduce(lambda x, y: x * y, range(2, n+1))
print sum([ int(n) for n in str(factorial(100))])