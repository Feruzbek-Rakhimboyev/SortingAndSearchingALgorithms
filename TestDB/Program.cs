using System.Text;

class Program
{
    #region Sorting Algorithms

    #region Quick Sort
    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Paritation(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }
    static int Paritation(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                if (i != j)
                    Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, right);
        return i + 1;
    }
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    #endregion

    #region Merge Sort
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            MergeArray(array, left, middle, right);
        }
    }
    static void MergeArray(int[] array, int left, int middle, int right)
    {
        var leftArrayLength = middle - left + 1;
        var rightArrayLength = right - middle;
        var leftTempArray = new int[leftArrayLength];
        var rightTempArray = new int[rightArrayLength];
        int i, j;

        for (i = 0; i < leftArrayLength; i++)
            leftTempArray[i] = array[left + i];
        for (j = 0; j < rightArrayLength; j++)
            rightTempArray[j] = array[middle + 1 + j];
        i = 0;
        j = 0;
        int k = left;

        while (i < leftArrayLength && j < rightArrayLength)
        {
            if (leftTempArray[i] <= rightTempArray[j])
            {
                array[k++] = leftTempArray[i++];
            }
            else
            {
                array[k++] = rightTempArray[j++];
            }
        }

        while (i < leftArrayLength)
        {
            array[k++] = leftTempArray[i++];
        }

        while (j < rightArrayLength)
        {
            array[k++] = rightTempArray[j++];
        }
    }
    #endregion

    #region Radix Sort
    public static void RadixSortFunc(int[] arr)
    {
        int max = GetMax(arr);

        for (int exp = 1; max / exp > 0; exp *= 10)
            CountingSort(arr, exp);
    }

    private static int GetMax(int[] arr)
    {
        int max = arr[0];
        foreach (int num in arr)
        {
            if (num > max)
                max = num;
        }
        return max;
    }

    private static void CountingSort(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        foreach (int num in arr)
            count[(num / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        Array.Copy(output, arr, n);
    }
    #endregion

    #region Counting Sort
    public static void CountSort(int[] array)
    {
        int maxValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
                maxValue = array[i];
        }
        int[] count = new int[maxValue + 1];
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }
        for (int i = 1; i <= maxValue; i++)
        {
            count[i] += count[i - 1];
        }
        int[] temp = new int[array.Length];
        for (int i = array.Length - 1; i >= 0; i--)
        {
            temp[count[array[i]] - 1] = array[i];
            count[array[i]]--;
        }
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = temp[i];
        }
    }
    #endregion

    #region Bubble Sort
    public static int[] BubbleSort(int[] arr)
    {
        bool continueValue = true;
        while (continueValue)
        {
            continueValue = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    continueValue = true;
                }
            }
        }
        return arr;
    }
    #endregion

    #region Insertion Sort
    public static int[] InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int currentElement = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > currentElement)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = currentElement;
        }
        return arr;
    }
    #endregion

    #region Selection Sort
    public static int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[minIndex] > arr[j])
                    minIndex = j;
            if (minIndex != i)
                Swap(arr, i, minIndex);
        }
        return arr;
    }
    #endregion

    #region Heap Sort
    public static void HeapSort(int[] array)
    {
        int n = array.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);
        for (int i = n - 1; i > 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;
            Heapify(array, i, 0);
        }
    }

    static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if (left < n && array[left] > array[largest])
            largest = left;
        if (right < n && array[right] > array[largest])
            largest = right;
        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;
            Heapify(array, n, largest);
        }
    }
    #endregion

    #endregion

    #region Function
    public static void PrintArray(int[] arr)
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            str.Append(arr[i] + " ");
        }
        Console.WriteLine(str);
    }
    #endregion

    #region Searching Algorithms

    #region Linear Searching
    static int LinearSearching<T>(T[] array, T element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(element))
                return i;
        }
        return -1;
    }
    #endregion

    #region Binary Search 
    static int BinarySearch(int[] array, int element)
    {
        int left = 0;
        int right = array.Length - 1;
        while (left <= right)
        {
            int currentIndex = (left + right) / 2;
            if (array[currentIndex] == element)
                return currentIndex;
            else if (array[currentIndex] < element)
                left = currentIndex + 1;
            else
                right = currentIndex - 1;
        }
        return -1;
    }
    #endregion

    #region Fibonachchi Search
    public static int FibonacciSearch(int[] arr, int x)
    {
        int n = arr.Length;
        int fibMMinus2 = 0;
        int fibMMinus1 = 1;
        int fibM = fibMMinus1 + fibMMinus2;
        while (fibM < n)
        {
            fibMMinus2 = fibMMinus1;
            fibMMinus1 = fibM;
            fibM = fibMMinus1 + fibMMinus2;
        }

        int offset = -1;
        while (fibM > 1)
        {
            int i = Math.Min(offset + fibMMinus2, n - 1);
            if (arr[i] < x)
            {
                fibM = fibMMinus1;
                fibMMinus1 = fibMMinus2;
                fibMMinus2 = fibM - fibMMinus1;
                offset = i;
            }
            else if (arr[i] > x)
            {
                fibM = fibMMinus2;
                fibMMinus1 = fibMMinus1 - fibMMinus2;
                fibMMinus2 = fibM - fibMMinus1;
            }
            else return i;
        }
        if (fibMMinus1 == 1 && arr[offset + 1] == x)
            return offset + 1;
        return -1;
    }
    #endregion

    #endregion

    static void Main(string[] args)
    {
        Console.WriteLine("Elementlar sonini kiriting:");
        int n = Int32.Parse(Console.ReadLine());
        Random random = new Random(10);
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = random.Next(1, 10001);
        }
        Console.WriteLine("Dastlabki elementlar:\n");
        PrintArray(arr);
        Console.WriteLine("Saralangandan keyingi elementlar:\n");
        HeapSort(arr);
        PrintArray(arr);
        Console.WriteLine("Izlamoqchi bo'lgan elementni kiriting:");
        int element = Int32.Parse(Console.ReadLine());
        int indexOfElement = FibonacciSearch(arr, element);
        if (indexOfElement != -1)
            Console.WriteLine($"Izlanayotgan element indeksi: {indexOfElement}");
        else
            Console.WriteLine("Bunday element majud emas!");
    }
}
