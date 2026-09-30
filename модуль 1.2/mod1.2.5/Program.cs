using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива (K): ");
        int k = Convert.ToInt32(Console.ReadLine());
        char[] russianAlphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        char[] sourceArray = new char[k];
        Random rand = new Random();
        List<char> consonantsList = new List<char>();
        for (int i = 0; i < k; i++)
        {
            sourceArray[i] = russianAlphabet[rand.Next(russianAlphabet.Length)];
            bool isVowel = Array.Exists(vowels, v => v == sourceArray[i]);
            if (!isVowel)
            {
                consonantsList.Add(sourceArray[i]);
            }
        }
        char[] consonantsArray = consonantsList.ToArray();
        Console.WriteLine("Первый массив (все буквы): " + string.Join(", ", sourceArray));
        Console.WriteLine("Второй массив (только согласные): " + string.Join(", ", consonantsArray));
    }
}
