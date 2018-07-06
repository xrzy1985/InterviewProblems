'''
James Patterson
james.patterson@themerakicode.com
Windows 10 cmd with Python 3.5
python pythonSolution.py
'''


centerLineDistance = 10.0

currentLocation = 0.0

n = int(input("Enter the Number of Events: "))

def AddToFreeSpaceList(s, e, l):
	newList = [s, e]
	l.append(newList)
	
	
def Solve(loc, dist, n):
	freeSpace = []
	
	cnt = 1
	
	while cnt <= n:
		
		str = input("Enter an event: ")
		
		list = [float(x) for x in str.split(" ")]
		
		list.sort()
		
		minimum = min(list)
		
		maximum = max(list)
		
		if (n == 1):
			
			if(minimum == loc):
				AddToFreeSpaceList(maximum, dist, freeSpace)
				
			elif (maximum == dist):
				AddToFreeSpaceList(loc, minimum, freeSpace)
				
			else:
				AddToFreeSpaceList(loc, minimum, freeSpace)
				AddToFreeSpaceList(maximum, dist, freeSpace)
			
		if (n > 1):
		
			if(minimum == loc):
				
				if(cnt == 1):
					loc = maximum
					
				else:
					if(maximum >= dist):
						if(maximum == dist):
							return(freeSpace)
							break
						else:
							return(freeSpace)
							break
					else:
						AddToFreeSpaceList(maximum, dist, freeSpace)
				
			elif (minimum > loc):
				
				AddToFreeSpaceList(loc, minimum, freeSpace)
				
				if(maximum >= dist):
					
					if(maximum == dist):
						return(freeSpace)
						break
					else:
						return(freeSpace)
						break
					
				else:
					
					if(cnt == n):
						AddToFreeSpaceList(maximum, dist, freeSpace)
					else:
						loc = maximum
					
		
		cnt += 1
		
	return (freeSpace)
	
	
print(Solve(currentLocation, centerLineDistance, n))


	
	
	


