using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите целое число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine($"Число {number} является четным.");
        }
        else
        {
            Console.WriteLine($"Число {number} является нечетным.");
        }
    }
}