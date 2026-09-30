using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.Write("Введите размер квадратной матрицы (N): ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] matrix = new int[n][];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = rand.Next(-50, 51);
            }
        }
        Console.WriteLine("\nИсходная матрица и суммы ее строк:");
        PrintMatrixWithSums(matrix);
        matrix = matrix.OrderBy(row => row.Sum()).ToArray();
        Console.WriteLine("\nМатрица после сортировки строк по возрастанию сумм:");
        PrintMatrixWithSums(matrix);
    }
        static void PrintMatrixWithSums(int[][] mat)
    {
        for (int i = 0; i < mat.Length; i++)
        {
            string rowStr = string.Join("\t", mat[i]);
            int sum = mat[i].Sum();
            Console.WriteLine($"{rowStr}  | Сумма = {sum}");
        }
    }
}
