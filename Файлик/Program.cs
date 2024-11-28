using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков
{
    internal class Program
    {
        public enum Month
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB) //перемножение матриц
        {
            int rowA = matrixA.GetLength(0);
            int colA = matrixA.GetLength(1);
            int colB = matrixB.GetLength(1);

            int[,] matrixAB = new int[rowA, colB];

            for (int i = 0; i < rowA; i++)
            {
                for (int j = 0; j < colB; j++)
                {
                    for (int k = 0; k < colA; k++)
                    {
                        matrixAB[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixAB;
        }
        public static void PrintMatrix(int[,] matrix) // вывод матриц на экран
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + "\t");  // \t чтобы было визуально красиво
                }
                Console.WriteLine();
            }
        }
        public static double[,] GenerateRandomTemperature(int rows, int cols) //генерация рандомный температуры
        {
            Random random = new Random();
            double[,] temperature = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    temperature[i, j] = random.Next(-100, 300) / 10.0;
                }
            }
            return temperature;
        }

        public static double[] CalculateAverageMonthlyTemperatures(double[,] temperature) //средняя температура для каждого месяца
        {
            int rows = temperature.GetLength(0);
            double[] averageTemperatures = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    sum += temperature[i, j];
                }
                averageTemperatures[i] = sum / temperature.GetLength(1);
            }
            return averageTemperatures;
        }

        public static double CalculateYearAverage(double[] averageTemperatures) // средняя темп за год
        {
            double sum = 0;
            foreach (double temp in averageTemperatures)
            {
                sum += temp;
            }
            return sum / averageTemperatures.Length;
        }
        static void Main(string[] args)
        {
            /*Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива.В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц(на вход две матрицы, возвращаемое значение – матрица)*/
            Console.WriteLine("Упражнение 6.2");
            Console.WriteLine();

            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 10, 20 }, { 30, 40 } };
            int[,] matrixAB = MultiplyMatrices(matrixA, matrixB);

            // Вывод результатов
            Console.WriteLine("Матрица A:");
            PrintMatrix(matrixA);
            Console.WriteLine("Матрица B:");
            PrintMatrix(matrixB);
            Console.WriteLine("Результат перемножения матриц A и B:");
            PrintMatrix(matrixAB);
            Console.ReadLine();


            /*Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур. Полученный массив средних температур отсортировать по
            возрастанию.*/
            Console.WriteLine("Упражнение 6.3");

            int rows = 12;
            int cols = 30;
            double[,] temperature = GenerateRandomTemperature(rows, cols);
            double[] averageTemperatures = CalculateAverageMonthlyTemperatures(temperature);
            Console.WriteLine("Средние температуры для каждого месяца:");
            for (int i = 0; i < averageTemperatures.Length; i++)
            {
                Console.WriteLine($"{((Month)i).ToString()}: {averageTemperatures[i]:F2} °C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("Средние температуры по возрастанию:");
            foreach (double avgTemp in averageTemperatures)
            {
                Console.WriteLine($"{avgTemp:F2} °C");
            }
            double yearAverage = CalculateYearAverage(averageTemperatures);
            Console.WriteLine($"Средняя температура за год в градусах цельсия: {yearAverage:F2}");
            Console.ReadLine();

            
            

        }


    }

}

  


    
