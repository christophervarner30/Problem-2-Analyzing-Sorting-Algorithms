using System;
using System.Diagnostics;

public class SortingAlgorithmsAnalysis
{
    // Quick Sort
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Merge Sort
    static void MergeSort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        int[] leftArray = new int[middle - left + 1];
        int[] rightArray = new int[right - middle];

        Array.Copy(arr, left, leftArray, 0, middle - left + 1);
        Array.Copy(arr, middle + 1, rightArray, 0, right - middle);

        int i = 0;
        int j = 0;
        int k = left;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] <= rightArray[j])
            {
                arr[k++] = leftArray[i++];
            }
            else
            {
                arr[k++] = rightArray[j++];
            }
        }

        while (i < leftArray.Length)
        {
            arr[k++] = leftArray[i++];
        }

        while (j < rightArray.Length)
        {
            arr[k++] = rightArray[j++];
        }
    }

    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                }
            }
        }
    }

    // Insertion Sort
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    // Function to measure execution time of a sorting algorithm
    static long MeasureSortingTime(Action<int[]> sortAlgorithm, int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        sortAlgorithm(array);
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Function to generate an array of random integers
    static int[] GenerateRandomArray(int length, int minValue, int maxValue)
    {
        Random rand = new Random();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = rand.Next(minValue, maxValue + 1);
        }
        return array;
    }

    static void Main(string[] args)
    {
        int arraySize = 100000;
        int minValue = 1;
        int maxValue = 1000;
        int[] array = GenerateRandomArray(arraySize, minValue, maxValue);

        Console.WriteLine($"Array Size: {arraySize}");
        Console.WriteLine("Algorithm:\tTime Taken (ms):");

        // Correcting the QuickSort call:
        Console.WriteLine($"Quick Sort:\t{MeasureSortingTime((arr) => QuickSort(arr, 0, arr.Length - 1), array.Clone() as int[])}");

        Console.WriteLine($"Merge Sort:\t{MeasureSortingTime(MergeSort, array.Clone() as int[])}");
        Console.WriteLine($"Bubble Sort:\t{MeasureSortingTime(BubbleSort, array.Clone() as int[])}");
        Console.WriteLine($"Insertion Sort:\t{MeasureSortingTime(InsertionSort, array.Clone() as int[])}");
    }
}
// Quick and Merge Sort both have an average time complexity of O (n log n) which is considered efficient for large datasets. They divide the problem into smaller subproblems. Bubble and Insertion sort have an average time of O(n^2), making them very inefficient. They swap as the data size grows.