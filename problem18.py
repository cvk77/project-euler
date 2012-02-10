f = open("triangle18.txt", "r")
data=[[int(x) for x in line.split(' ')] for line in f]
f.close()

L = len(data)
N = 2 ** (L - 1) 

i, max = 0, 0
while i < N:
    n, sum = 0, 0
    for j in range(0, L):
        if i & (2 ** (L-j-1)) > 0:
            n += 1
        sum += data[j][n]
    if sum > max: max = sum
    i += 1
    
print max        
