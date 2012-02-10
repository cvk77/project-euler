def is_divisable_by_all(n, upto):
	for d in range(upto+1, upto / 2, -1):
		if n % d != 0:
			return False
	return True

prims = 2*3*5*7*11*13*17*19
p = prims

while not is_divisable_by_all(p, upto=20):
	p = p + prims

print p