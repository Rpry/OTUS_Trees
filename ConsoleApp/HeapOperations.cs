namespace ConsoleApp;

public static class HeapOperations
{
    public static int[] DeleteRoot(int[] a)
    {
        int lastElement = a[a.Length - 1];
        a[0] = lastElement;
        a[a.Length - 1] = 0;
        int[] newArray = new int[a.Length - 1];
        Array.Copy(a, newArray, a.Length - 1);
        MaxHeapify(newArray, 0);
        return newArray;
    }
    
    public static int[] AddNode(int[] a, int value)
    {
        int[] newArray = new int[a.Length + 1];
        Array.Copy(a, newArray, a.Length);
        newArray[newArray.Length - 1] = value;
        HeapifyWithBottomUp(newArray, newArray.Length - 1);
        return newArray;
    }

    public static void MaxHeapify(int[] a, int currentNodeNumber)
    {
        int largestNodeNumber = currentNodeNumber;
        var leftNodeNumber = 2 * currentNodeNumber + 1;
        var rightNodeNumber = 2 * currentNodeNumber + 2;
        //сравниваем текущий с левым
        if (leftNodeNumber < a.Length && a[leftNodeNumber] > a[currentNodeNumber])
        {
            largestNodeNumber = leftNodeNumber;
        }
        //сравниваем наибольший из текущего и левого с правым
        if (rightNodeNumber < a.Length && a[rightNodeNumber] > a[largestNodeNumber])
        {
            largestNodeNumber = rightNodeNumber;
        }

        //текущий узел не является наибольшим
        if (largestNodeNumber != currentNodeNumber)
        {
            int temp = a[currentNodeNumber];
            a[currentNodeNumber] = a[largestNodeNumber];
            a[largestNodeNumber] = temp;
            //проходим вниз
            MaxHeapify(a, largestNodeNumber);
        }
    }

    static void HeapifyWithBottomUp(int[] array, int i)
    {
        int parent = (i - 1) / 2;
        if (parent >= 0) {
            if (array[i] > array[parent])
            {
                // меняем местами родителя и текущий узел
                int temp = array[i];
                array[i] = array[parent];
                array[parent] = temp;
 
                // Вызываем рекурсивно для нового родителя
                HeapifyWithBottomUp(array, parent);
            }
        }
    }
    
    public static int[] BuildMaxHeap(int[] a)
    {
        var leftStartPos = ((int)Math.Round((decimal)a.Length / 2)) + 1;
        for (int i = leftStartPos; i >= 0; i--)
        {
            MaxHeapify(a, i);
        }

        return a;
    }
}