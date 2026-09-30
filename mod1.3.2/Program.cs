using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Write("Введите максимальное число для суммы: ");
        int targetSum = Convert.ToInt32(Console.ReadLine());
        if (targetSum <= 0)
        {
            Console.WriteLine("Число должно быть больше нуля.");
            return;
        }
        Random rand = new Random();
        List<int> numbers = new List<int>();
        int currentSum = 0;
        while (true)
        {
            int nextVal = rand.Next(1, 9);
            if (currentSum + nextVal > targetSum)
            {
                break; // прекращаем, чтобы сумма не превысила заданное число
            }
            numbers.Add(nextVal);
            currentSum += nextVal;
        }
        Console.WriteLine($"Сгенерированный массив: {string.Join(", ", numbers)}");
        Console.WriteLine($"Общая сумма элементов: {currentSum} (лимит: {targetSum})");
    }
}