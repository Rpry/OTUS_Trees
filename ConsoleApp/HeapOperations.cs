namespace ConsoleApp;

public static class HeapOperations
{
    public static int[] DeleteRoot(int[] array)
    {
        int lastElement = array[array.Length - 1];
        array[0] = lastElement;
        array[array.Length - 1] = 0;
        int[] newArray = new int[array.Length - 1];
        Array.Copy(array, newArray, array.Length - 1);
        MaxHeapify(newArray, 0);
        return newArray;
    }
    
    public static int[] AddNode(int[] array, int newNodeValue)
    {
        int[] newArray = new int[array.Length + 1];
        Array.Copy(array, newArray, array.Length);
        newArray[newArray.Length - 1] = newNodeValue;
        HeapifyWithBottomUp(newArray, newArray.Length - 1);
        return newArray;
    }

    /// <summary>
    /// Для максимальной кучи
    /// Перестройка для переданного индекса и вниз
    /// </summary>
    public static void MaxHeapify(int[] array, int currentNodeIndex)
    {
        int largestNodeIndex = currentNodeIndex;
        var leftNodeIndex = 2 * currentNodeIndex + 1;
        var rightNodeIndex = 2 * currentNodeIndex + 2;
        //сравниваем текущий с левым
        if (leftNodeIndex < array.Length && array[leftNodeIndex] > array[currentNodeIndex])
        {
            largestNodeIndex = leftNodeIndex;
        }
        //сравниваем наибольший из текущего и левого с правым
        if (rightNodeIndex < array.Length && array[rightNodeIndex] > array[largestNodeIndex])
        {
            largestNodeIndex = rightNodeIndex;
        }

        //текущий узел не является наибольшим
        if (largestNodeIndex != currentNodeIndex)
        {
            int temp = array[currentNodeIndex];
            array[currentNodeIndex] = array[largestNodeIndex];
            array[largestNodeIndex] = temp;
            //проходим вниз
            MaxHeapify(array, largestNodeIndex);
        }
    }

    /// <summary>
    /// Для максимальной кучи
    /// При добавлении узла перестройка вверх
    /// </summary>
    static void HeapifyWithBottomUp(int[] array, int elementIndex)
    {
        int parentIndex = (elementIndex - 1) / 2;
        if (parentIndex >= 0) {
            if (array[elementIndex] > array[parentIndex])
            {
                // меняем местами родителя и текущий узел
                int temp = array[elementIndex];
                array[elementIndex] = array[parentIndex];
                array[parentIndex] = temp;
 
                // Вызываем рекурсивно для нового родителя
                HeapifyWithBottomUp(array, parentIndex);
            }
        }
    }
    
    public static int[] BuildMaxHeap(int[] array)
    {
        var leftStartPos = ((int)Math.Round((decimal)array.Length / 2)) + 1;
        for (int i = leftStartPos; i >= 0; i--)
        {
            MaxHeapify(array, i);
        }

        return array;
    }
}