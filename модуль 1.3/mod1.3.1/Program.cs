using System;
class Program
{
    static int GetGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
        static void Main()
    {
        Console.Write("Введите неотрицательный числитель: ");
        int numerator = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите положительный знаменатель: ");
        int denominator = Convert.ToInt32(Console.ReadLine());
        if (numerator < 0 || denominator <= 0)
        {
            Console.WriteLine("Ошибка: числитель должен быть >= 0, а знаменатель > 0.");
            return;
        }
        Console.WriteLine($"Исходная дробь: {numerator}/{denominator}");
        if (numerator == 0)
        {
            Console.WriteLine("Сокращенная дробь: 0/1 (или 0)");
            return;
        }
        int gcd = GetGCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
        Console.WriteLine($"Сокращенная дробь: {numerator}/{denominator}");
    }
}