using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку для проверки: ");
        string input = Console.ReadLine();
        string cleanInput = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        string reversedInput = new string(cleanInput.Reverse().ToArray());
        if (cleanInput == reversedInput)
        {
            Console.WriteLine("Строка является палиндромом!");
        }
        else
        {
            Console.WriteLine("Строка НЕ является палиндромом.");
        }
    }
}
