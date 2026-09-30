using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите количество простых чисел (K): ");
        
        int k = Convert.ToInt32(Console.ReadLine());

        if (k <= 0)
        {
            Console.WriteLine("Количество должно быть больше нуля.");
            return;
        }
        int count = 0;
        int number = 2;
        Console.WriteLine($"\nПервые {k} простых чисел:");
        while (count < k)
        {
            if (IsPrime(number))
            {
                Console.Write($"{number,6} ");
                count++;
                if (count % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            number++;
        }
        Console.WriteLine();
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }
}
