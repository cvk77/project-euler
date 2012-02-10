with open("data/names.txt", "r") as f:
    names = f.read().replace("\"", "").split(",")
names.sort()

namescore = lambda pos, name: sum(map(lambda c: ord(c) - 64, list(name))) * pos    
print sum([ namescore(pos+1, value) for pos, value in enumerate(names) ])
