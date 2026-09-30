using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива (N): ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] array = new double[n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Элемент [{i}]: ");
            array[i] = Convert.ToDouble(Console.ReadLine());
        }
        double maxAbs = Math.Abs(array[0]);
        for (int i = 1; i < n; i++)
        {
            if (Math.Abs(array[i]) > maxAbs)
            {
                maxAbs = Math.Abs(array[i]);
            }
        }
        Console.WriteLine($"\nМаксимальный по модулю элемент: {maxAbs}");
        if (maxAbs == 0)
        {
            Console.WriteLine("Ошибка: максимальный по модулю элемент равен 0, нормировка невозможна.");
            return;
        }
        Console.WriteLine("Нормированный массив:");
        for (int i = 0; i < n; i++)
        {
            array[i] = array[i] / maxAbs;
            Console.Write($"{array[i]:F2} ");
        }
        Console.WriteLine();
    }
}