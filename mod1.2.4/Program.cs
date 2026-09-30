using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива (K): ");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите левую границу диапазона (A): ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите правую границу диапазона (B): ");
        int b = Convert.ToInt32(Console.ReadLine());
        if (k <= 0 || a >= b)
        {
            Console.WriteLine("Некорректные данные.");
            return;
        }
        int[] array = new int[k];
        Random rand = new Random();
        for (int i = 0; i < k; i++)
        {
            array[i] = rand.Next(a, b);
        }

        Console.WriteLine("Массив: " + string.Join(", ", array));
        int minIndex = 0;
        int maxIndex = 0;
        for (int i = 1; i < k; i++)
        {
            if (array[i] < array[minIndex]) minIndex = i;
            if (array[i] > array[maxIndex]) maxIndex = i;
        }
        Console.WriteLine($"Мин. элемент: {array[minIndex]} (индекс {minIndex})");
        Console.WriteLine($"Макс. элемент: {array[maxIndex]} (индекс {maxIndex})");

        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);
        Console.WriteLine("Элементы между минимальным и максимальным (включая их):");
        for (int i = start; i <= end; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }
}
