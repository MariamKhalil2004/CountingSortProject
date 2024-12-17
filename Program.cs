using System;

class CountingSort
{
    // Counting-Sort Algorithm
    public static void CountingSortAlgorithm(int[] arr)
    {
        int max = arr[0];
        int min = arr[0];

        // Find max and min elements in the array
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
            if (arr[i] < min)
                min = arr[i];
        }

        // Create the counting array and initialize it to 0
        int range = max - min + 1;
        int[] count = new int[range];
        int[] output = new int[arr.Length];

        // Store the count of each number in the count array
        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - min]++;
        }

        // Change count[i] to be the cumulative sum of counts
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array using the count array
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i] - min] - 1] = arr[i];
            count[arr[i] - min]--;
        }

        // Copy the sorted elements back into the original array
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }

    // Method to print an array
    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Example array
        int[] arr = { 4, 2, 2, 8, 3, 3, 1 };

        Console.WriteLine("Original Array:");
        CountingSort.PrintArray(arr);

        // Sort the array using Counting Sort
        CountingSort.CountingSortAlgorithm(arr);

        Console.WriteLine("Sorted Array:");
        CountingSort.PrintArray(arr);
    }
}
