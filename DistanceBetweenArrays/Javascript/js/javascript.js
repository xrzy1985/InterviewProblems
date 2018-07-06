var currentLocation = 0.0;

var centerLineDistance = 10.0;

var numberOfEvents = 5;

// change out data and data0 to debug
var data = [0, 1.3];
var data0 = [1, 1.3];
var data1 = [2.45, 3];
var data2 = [6.6, 4];
var data3 = [7.1, 8];
// change out data4 and data5 to debug
var data4 = [8.5, 9];
var data5 = [9.5, 10]

// just change the numberOfEvents to 1-5
var arr5 = [data0, data1, data2, data3, data5];

function AddToFreeSpace(start, end, arr)
{
	var temp = [start, end];
    arr.push(temp);
    return true;
}

function Min(arr)
{
    var t = arr;
    t.sort(function(a, b){return a-b});
    return t[0]
}

function Max(arr)
{
    var t = arr;
    t.sort(function(a, b){return b-a});
    return t[0]
}

function Solve(loc, dist, n, arr)
{
	var freeSpace = []

    for(var i = 0; i < n; i++)
    {
        var max = arr[i];
        max.sort(function(a, b){return b-a});

        // max[1] for minimum
        // max[0] for maximum

        if(n == 1 && n <= 1)
        {
        	if(max[1] == loc)
            {
            	AddToFreeSpace(max[0], dist, freeSpace);
            }
            else if(max[0] == dist)
            {
            	AddToFreeSpace(loc, max[1], freeSpace);
            }
            else
            {
            	AddToFreeSpace(loc, max[1], freeSpace);
                AddToFreeSpace(max[0], dist, freeSpace);
            }
        }

        if(n > 1)
        {
        	if(max[1] == loc)
            {
            	if(i == 0)
                {
                	loc = max[0];
                }
                else
                {
                	if(max[0] >= dist)
                    {
                    	if(max[0] == dist)
                        {
                        	return freeSpace;
                        }
                        else
                        {
                        	break;
                        }
                    }
                    else
                    {
                    	AddToFreeSpace(max[0], dist, freeSpace);
                    }
                }
            }
            else if(max[1] > loc)
            {
            	AddToFreeSpace(loc, max[1], freeSpace);

                if(max[0] >= dist)
                {
                	if(max[0] == dist)
                    {
                        return freeSpace;
                    }
                    else{ break; }
                }

                else
                {
                    if(i == (n-1))
                    {
                        AddToFreeSpace(max[0], dist, freeSpace);
                    }
                    else
                    {
                        loc = max[0];
                    }
                }
            }
        }
    }

    return freeSpace;

}
