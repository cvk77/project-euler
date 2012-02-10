from tools import factorial

def perm(l, n):
    if len(l) <= 1:
        return l
    fct = factorial(len(l)-1)
    q, r = n / fct, n % fct
    return [l[q]] + perm(l[:q] + l[q+1:], r)

print "".join(map(str, perm(range(10), 999999)))

