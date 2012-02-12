print sum(filter(lambda x: sum(int(x)**5 for x in str(x)) == x, xrange(2, 5*9**5)))
