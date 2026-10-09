using System;
// Объявление делегата для метода сортировки массива
delegate void SortingAlgorithm(int[] array);
class Program
{
    // Алгоритм 1: Сортировка пузырьком
    static void BubbleSort(int[] array)
    {
        int temp;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("[Сортировка] Выполнена сортировка пузырьком.");
    }
    // Алгоритм 2: Быстрая сортировка (или встроенная Array.Sort)
    static void QuickSortWrapper(int[] array)
    {
        Array.Sort(array);
        Console.WriteLine("[Сортировка] Выполнена встроенная быстрая сортировка.");
    }
    // Метод выполнения сортировки с помощью делегата
    static void ProcessSorting(int[] array, SortingAlgorithm sorter)
    {
        sorter(array);
    }
    static void Main()
    {
        int[] numbers1 = { 64, 34, 25, 12, 22, 11, 90 };
        int[] numbers2 = { 5, 1, 4, 2, 8, 3, 9 };
        Console.WriteLine("Исходный массив 1: " + string.Join(", ", numbers1));
        // Передача метода сортировки пузырьком через делегат
        ProcessSorting(numbers1, BubbleSort);
        Console.WriteLine("Результат: " + string.Join(", ", numbers1) + "\n");
        Console.WriteLine("Исходный массив 2: " + string.Join(", ", numbers2));
        // Передача метода быстрой сортировки через делегат
        ProcessSorting(numbers2, QuickSortWrapper);
        Console.WriteLine("Результат: " + string.Join(", ", numbers2));
    }
}