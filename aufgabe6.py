UPTO = 100

square = lambda x: x*x

sosq = sum(map(square, range(1,UPTO+1)))
sqos = int(square((UPTO + 1) / 2.0 * UPTO))

print sqos - sosq