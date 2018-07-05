/*
James Patterson
james.patterson@themerakicode.com
Visual Studio 2017 C# Solution
*/

using System.Collections.Generic;
using System.Linq;
using System;

class Solution
{
    public static double centerLineDistance = 10.0;

    public static void AddToFreeSpaceList(double start, double end, List<double[]> arr)
    {
        double[] t = new double[] { start, end };

        arr.Add(t);
    }

    // Complete the solve function below.
    public static List<double[]> Solve(double loc, double dist, int n)
    {
        double[][] eventsArray = new double[n][];

        // A list that will be populated by arrays representing free space
        List<double[]> freeSpace = new List<double[]>();


        for (int i = 0; i < n; i++)
        {
            // The console will read an incoming string of double values,
            // split the string up every time it reaches a blank space,
            // convert those strings into double values, those values are
            // then converted into an array, and finally stored inside
            // the array, tempArray.
            double[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToDouble(x));

            // sort the array
            Array.Sort(arr);

            // as i progresses, a new array will be stored in each resulting row
            eventsArray[i] = arr;

            // find out the beginning of the Event
            double min = arr.Min();

            // find out the end of the Event
            double max = arr.Max();

            // if there is only 1 event
            if(n == 1)
            {
                // if the min value is equal to the actual starting location
                if(min == loc)
                {
                    // add the new free space location to the List
                    AddToFreeSpaceList(max, centerLineDistance, freeSpace);
                }
                // if the max value is equal to the end of the center line
                else if(max == centerLineDistance)
                {
                    // add the new free space location to the List
                    AddToFreeSpaceList(loc, min, freeSpace);

                }
                else
                {
                    // add the new free space location to the List
                    AddToFreeSpaceList(loc, min, freeSpace);

                    // add the new free space location to the List
                    AddToFreeSpaceList(max, centerLineDistance, freeSpace);
                }
            }

            // If we are dealing with more than one event
            if(n > 1)
            {
                // Occurs when the current location is equal to the min value of the event
                if(min == loc)
                {
                    // set our location to the max value of the event
                    loc = max;
                }
                else if(min > loc)
                {
                    // add the new free space location to the List
                    AddToFreeSpaceList(loc, min, freeSpace);

                    // if our current array has a max larger than our centerLineDistance
                    if(max >= centerLineDistance)
                    {
                        break;
                    }
                    // if we still have free space behind our current array
                    else
                    {
                        // if we are on the last item in the array
                        if (i == n - 1)
                        {
                            // add the new free space location to the List
                            AddToFreeSpaceList(max, centerLineDistance, freeSpace);
                        }
                        // if we are just in the middle of the array
                        else
                        {
                            loc = max;
                        }
                    }
                }
            }
        }
        // return our List of double[] arrays
        return freeSpace;
    }

    static void Main(string[] args)
    {
        // To track the current location along the center line
        double currentLocation = 0.0;

        Console.WriteLine("Enter the number of events: ");

        // store the number of events being passed in
        int n = Convert.ToInt32(Console.ReadLine());

        // create a List to hold our returned List
        List<double[]> result = Solve(currentLocation, centerLineDistance, n);

        // Print out our results
        Console.Write("\n");

        foreach (double[] arr in result)
        {
            Console.Write("Free Space: { ");

            foreach (double dd in arr)
            {
                Console.Write(dd + " ");
            }
            
            Console.WriteLine("}");
        }

        Console.WriteLine("\nPress any key to close...");
        Console.ReadKey();
    }
}
