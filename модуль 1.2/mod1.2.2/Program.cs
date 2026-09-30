using System;
class Program
{
    static void Main()
    {
        int[] array = { 5, 12, -3, 8, 42, 17, 0, -9, 24, 15 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", array));
        Console.Write("Введите целое число для замены максимального элемента: ");
        int replacement = Convert.ToInt32(Console.ReadLine());
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }

        Console.WriteLine($"Максимальный элемент был: {array[maxIndex]} (индекс {maxIndex})");
        array[maxIndex] = replacement;
        Console.WriteLine("Измененный массив: " + string.Join(", ", array));
    }
}
