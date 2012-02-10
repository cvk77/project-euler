import math

MAX = 2000000
l = [2] + range(3, MAX+1, 2)

for i in range(1, int(math.sqrt(MAX))):
    
    # Sieved out already?
    if l[i]: 
       
        # Remove multiples
        for j in range(l[i]*2, MAX+1, l[i]):
            if j % 2 != 0:
                l[j / 2] = 0
                        
print sum(l)