def is_palindrome(x):
    x = str(x)
    for i in range(0, len(x) / 2):
        if x[i] != x[-i-1]:
            return False
    return True
       
l = []       
for x in range(900, 1000):
    for y in range(900, 1000):
        if is_palindrome(x*y) and not x*y in l:
            l.append(x * y)

l.sort()
print l