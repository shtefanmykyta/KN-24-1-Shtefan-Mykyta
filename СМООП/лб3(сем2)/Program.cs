namespace лб3_сем2_
{
    using System;
    using System.IO;

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int[] array = null;

    //        Console.WriteLine("Виберіть спосіб введення даних:");
    //        Console.WriteLine("1. З файлу");
    //        Console.WriteLine("2. З клавіатури");
    //        Console.WriteLine("3. Випадкові числа");
    //        string choice = Console.ReadLine();

    //        switch (choice)
    //        {
    //            case "1":
    //                array = ReadFromFile("data.txt");
    //                break;
    //            case "2":
    //                array = ReadFromKeyboard();
    //                break;
    //            case "3":
    //                array = GenerateRandomArray();
    //                break;
    //            default:
    //                Console.WriteLine("Неправильний вибір.");
    //                return;
    //        }

    //        if (array != null)
    //        {
    //            int negativeCount = CountNegativeOddIndex(array);
    //            Console.WriteLine($"Кількість від’ємних елементів з непарними індексами: {negativeCount}");

    //            int[] everyThirdElementArray = GetEveryThirdElement(array);
    //            Console.WriteLine("Кожен третій елемент масиву:");
    //            foreach (var item in everyThirdElementArray)
    //            {
    //                Console.Write(item + " ");
    //            }
    //        }
    //    }

    //    static int[] ReadFromFile(string filePath)
    //    {
    //        try
    //        {
    //            string[] lines = File.ReadAllLines(filePath);
    //            int[] array = Array.ConvertAll(lines, int.Parse);
    //            return array;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Помилка при читанні з файлу: {ex.Message}");
    //            return null;
    //        }
    //    }

    //    static int[] ReadFromKeyboard()
    //    {
    //        Console.WriteLine("Введіть кількість елементів масиву:");
    //        int size = int.Parse(Console.ReadLine());
    //        int[] array = new int[size];

    //        Console.WriteLine("Введіть елементи масиву:");
    //        for (int i = 0; i < size; i++)
    //        {
    //            array[i] = int.Parse(Console.ReadLine());
    //        }

    //        return array;
    //    }

    //    static int[] GenerateRandomArray()
    //    {
    //        Random random = new Random();
    //        Console.WriteLine("Введіть кількість елементів масиву:");
    //        int size = int.Parse(Console.ReadLine());
    //        int[] array = new int[size];

    //        for (int i = 0; i < size; i++)
    //        {
    //            array[i] = random.Next(-100, 100);
    //        }

    //        return array;
    //    }

    //    static int CountNegativeOddIndex(int[] array)
    //    {
    //        int count = 0;
    //        for (int i = 1; i < array.Length; i += 2)
    //        {
    //            if (array[i] < 0)
    //            {
    //                count++;
    //            }
    //        }
    //        return count;
    //    }

    //    static int[] GetEveryThirdElement(int[] array)
    //    {
    //        int newSize = (array.Length + 2) / 3;
    //        int[] newArray = new int[newSize];

    //        for (int i = 0, j = 0; i < array.Length; i += 3, j++)
    //        {
    //            newArray[j] = array[i];
    //        }

    //        return newArray;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть тип масиву:");
            Console.WriteLine("1. Прямокутний масив");
            Console.WriteLine("2. Ступінчастий масив");
            string arrayTypeChoice = Console.ReadLine();

            int[,] rectangularArray = null;
            int[][] jaggedArray = null;

            Console.WriteLine("Виберіть спосіб введення даних:");
            Console.WriteLine("1. З файлу");
            Console.WriteLine("2. З клавіатури");
            Console.WriteLine("3. Випадкові числа");
            string inputMethod = Console.ReadLine();

            if (arrayTypeChoice == "1")
            {
                rectangularArray = GetRectangularArray(inputMethod);
                if (rectangularArray != null)
                {
                    ProcessRectangularArray(rectangularArray);
                }
            }
            else if (arrayTypeChoice == "2")
            {
                jaggedArray = GetJaggedArray(inputMethod);
                if (jaggedArray != null)
                {
                    ProcessJaggedArray(jaggedArray);
                }
            }
            else
            {
                Console.WriteLine("Неправильний вибір типу масиву.");
            }
        }

        static int[,] GetRectangularArray(string method)
        {
            Console.WriteLine("Введіть кількість рядків:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпців:");
            int cols = int.Parse(Console.ReadLine());
            int[,] array = new int[rows, cols];

            switch (method)
            {
                case "1":
                    return ReadRectangularFromFile(array);
                case "2":
                    return ReadRectangularFromKeyboard(array);
                case "3":
                    return GenerateRandomRectangularArray(rows, cols);
                default:
                    Console.WriteLine("Неправильний вибір способу введення.");
                    return null;
            }
        }

        static int[][] GetJaggedArray(string method)
        {
            Console.WriteLine("Введіть кількість рядків:");
            int rows = int.Parse(Console.ReadLine());
            int[][] array = new int[rows][];

            switch (method)
            {
                case "1":
                    return ReadJaggedFromFile(array);
                case "2":
                    return ReadJaggedFromKeyboard(array);
                case "3":
                    return GenerateRandomJaggedArray(rows);
                default:
                    Console.WriteLine("Неправильний вибір способу введення.");
                    return null;
            }
        }

        static int[,] ReadRectangularFromFile(int[,] array)
        {
            try
            {
                string[] lines = File.ReadAllLines("rectangular_data.txt");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    string[] values = lines[i].Split(' ');
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = int.Parse(values[j]);
                    }
                }
                return array;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні з файлу: {ex.Message}");
                return null;
            }
        }

        static int[,] ReadRectangularFromKeyboard(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"Введіть елемент [{i}, {j}]: ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return array;
        }

        static int[,] GenerateRandomRectangularArray(int rows, int cols)
        {
            Random random = new Random();
            int[,] array = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = random.Next(-10, 10);
            return array;
        }

        static int[][] ReadJaggedFromFile(int[][] array)
        {
            try
            {
                string[] lines = File.ReadAllLines("jagged_data.txt");
                for (int i = 0; i < array.Length; i++)
                {
                    string[] values = lines[i].Split(' ');
                    array[i] = new int[values.Length];
                    for (int j = 0; j < values.Length; j++)
                    {
                        array[i][j] = int.Parse(values[j]);
                    }
                }
                return array;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні з файлу: {ex.Message}");
                return null;
            }
        }

        static int[][] ReadJaggedFromKeyboard(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введіть кількість елементів для рядка {i}: ");
                int size = int.Parse(Console.ReadLine());
                array[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Введіть елемент [{i}, {j}]: ");
                    array[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return array;
        }

        static int[][] GenerateRandomJaggedArray(int rows)
        {
            Random random = new Random();
            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int size = random.Next(1, 5);
                array[i] = new int[size];
                for (int j = 0; j < size; j++)
                    array[i][j] = random.Next(-10, 10);
            }

            return array;
        }

        static void ProcessRectangularArray(int[,] array)
        {
            bool[] logicalVector = BuildLogicalVector(array);

            Console.WriteLine("Логічний вектор B:");
            foreach (var item in logicalVector)
                Console.Write(item ? "1 " : "0 ");

            SortColumns(array);

            Console.WriteLine("\nСортована матриця A:");
            PrintMatrix(array);
        }

        static void ProcessJaggedArray(int[][] array)
        {
            bool[] logicalVector = BuildLogicalVector(array);

            Console.WriteLine("Логічний вектор B:");
            foreach (var item in logicalVector)
                Console.Write(item ? "1 " : "0 ");

            SortJaggedColumns(array);

            Console.WriteLine("\nСортована ступінчаста матриця A:");
            PrintJaggedArray(array);
        }

        static bool[] BuildLogicalVector(int[,] array)
        {
            bool[] logicalVector = new bool[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int positiveCount = 0;
                int negativeCount = 0;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0) positiveCount++;
                    else if (array[i, j] < 0) negativeCount++;
                }

                logicalVector[i] = positiveCount > negativeCount;
            }

            return logicalVector;
        }

        static bool[] BuildLogicalVector(int[][] array)
        {
            bool[] logicalVector = new bool[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int positiveCount = 0;
                int negativeCount = 0;

                foreach (var item in array[i])
                {
                    if (item > 0) positiveCount++;
                    else if (item < 0) negativeCount++;
                }

                logicalVector[i] = positiveCount > negativeCount;
            }

            return logicalVector;
        }

        static void SortColumns(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int[] columnData = new int[array.GetLength(0)];
                for (int row = 0; row < array.GetLength(0); row++)
                    columnData[row] = array[row, col];

                Array.Sort(columnData);
                Array.Reverse(columnData);

                for (int row = 0; row < array.GetLength(0); row++)
                    array[row, col] = columnData[row];
            }
        }

        static void SortJaggedColumns(int[][] array)
        {
            int maxLength = 0;

            foreach (var row in array)
                maxLength = Math.Max(maxLength, row.Length);

            for (int col = 0; col < maxLength; col++)
            {
                List<int> columnData = new List<int>();

                for (int row = 0; row < array.Length; row++)
                {
                    if (col < array[row].Length)
                        columnData.Add(array[row][col]);
                }

                columnData.Sort();
                columnData.Reverse();

                for (int row = 0; row < columnData.Count; row++)
                    if (row < array.Length && col < array[row].Length)
                        array[row][col] = columnData[row];
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t");

                Console.WriteLine();
            }
        }

        static void PrintJaggedArray(int[][] jaggedArray)
        {
            foreach (var row in jaggedArray)
            {
                foreach (var item in row)
                    Console.Write(item + "\t");

                Console.WriteLine();
            }
        }
    }
}
