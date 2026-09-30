using System;
using System.Linq;
class Program
{
    static void Main()
    {
        double[] array = new double[10];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = -10 + rand.NextDouble() * 20;
        }
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"[{i}] = {array[i]:F2}");
        }
        int[] indices = Enumerable.Range(0, array.Length)
                                 .OrderBy(i => array[i])
                                 .ToArray();
        Console.WriteLine("\nМассив индексов в порядке возрастания элементов:");
        Console.WriteLine(string.Join(", ", indices));
        Console.WriteLine("\nПроверка отсортированных значений по индексам:");
        foreach (int idx in indices)
        {
            Console.WriteLine($"Индекс {idx}: {array[idx]:F2}");
        }
    }
}