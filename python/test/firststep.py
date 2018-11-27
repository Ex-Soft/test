count = 1
while count < 11 :
	print(count)
	count = count + 1

if count == 11 :
	print('Counting complete.')

myvar = 3
myvar += 2
mystring = "Hello"
mystring += " world"
print(myvar)
print(mystring)
myvar, mystring = mystring, myvar
print(myvar)
print(mystring)

rangelist = range(10)
print(rangelist)

for number in rangelist:
    # Check if number is one of
    # the numbers in the tuple.
    if number in (3, 4, 7, 9):
        # "Break" terminates a for without
        # executing the "else" clause.
        break
    else:
        # "Continue" starts the next iteration
        # of the loop. It's rather useless here,
        # as it's the last statement of the loop.
        continue
else:
    # The "else" clause is optional and is
    # executed only if the loop didn't "break".
    pass # Do nothing

if rangelist[1] == 2:
    print("The second item (lists are 0-based) is 2")
elif rangelist[1] == 3:
    print("The second item (lists are 0-based) is 3")
else:
    print("Dunno")

while rangelist[1] == 1:
    pass

