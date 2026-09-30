using System;
class Program
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 11);
        Console.WriteLine("Я загадал число от 1 до 10. Попробуйте угадать его!");
        Console.Write("Ваш вариант: ");
        int userGuess = Convert.ToInt32(Console.ReadLine());
        if (userGuess == secretNumber)
        {
            Console.WriteLine("Поздравляем! Вы угадали число!");
        }
        else
        {
            Console.WriteLine($"Вы не угадали. Было загадано число: {secretNumber}");
        }
    }
}
