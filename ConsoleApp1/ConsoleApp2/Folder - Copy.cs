using System;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int searchSize = sortedArray.Length / 2;
        int searchTarget = sortedArray.Length / 2;
        while (searchSize > 0)
        {
            int foundNumber = sortedArray[searchTarget];
            int increment1 = searchSize / 2;
            if (foundNumber > lessThan) increment1 *= -1;

            searchTarget += increment1;
            searchSize /= 2;

        }

        int increment = sortedArray[searchTarget] >= lessThan ? -1 : 1;
        while (searchTarget >= 0 && searchTarget +1 < sortedArray.Length)
        {

            if (sortedArray[searchTarget] < lessThan && sortedArray[searchTarget + 1] >= lessThan)
                return searchTarget + 1;
            searchTarget += increment;
        }


        return searchTarget;
    }

    public static int searchBinary(int[] sortedArray, int target)
    {
        int searchSize = sortedArray.Length /2;
        int searchTarget = sortedArray.Length / 2;
        while(searchSize > 0)
        {
            int foundNumber = sortedArray[searchTarget];
            int increment1 = searchSize / 2;
            if (foundNumber > target) increment1 *= -1;

            searchTarget += increment1;
            searchSize /= 2;
           
        }

        int increment = sortedArray[searchTarget] >= target ? -1 : 1;
        while( searchTarget >= 0 && searchTarget < sortedArray.Length)
        {
            searchTarget += increment;
            if (sortedArray[searchTarget] < target && sortedArray[searchTarget + 1] > target)
                return searchTarget;
        }


        return searchTarget +1;
    }

    public static void MainFailed(string[] args)
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
        Console.ReadLine();
    }
}