from tools import is_prime

x,n = 1,0
while n < 10001:
    x = x + 1
    if is_prime(x):
        n = n + 1
    
print x 