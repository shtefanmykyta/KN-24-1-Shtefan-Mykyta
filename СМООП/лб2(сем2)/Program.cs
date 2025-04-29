namespace лб2_сем2_
{
    using System;

    //class Program
    //{
    //    static void Main()
    //    {
    //        double[] aValues = { 1, 2, 3, 4 };

    //        double xStart = 1;
    //        double xEnd = 10;
    //        double dx = 0.5;

    //        foreach (double a in aValues)
    //        {
    //            Console.WriteLine($"Результати для a = {a}:");
    //            for (double x = xStart; x <= xEnd; x += dx)
    //            {
    //                double y = CalculateY(x, a);
    //                Console.WriteLine($"x = {x:F1}, y = {y:F4}");
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //    static double CalculateY(double x, double a)
    //    {
    //        return -Math.Log(Math.Abs(x + a) / (1 + x * x));
    //    }
    //}

    //class Program
    //{
    //    static double y(double x)
    //    {
    //        return x * (1 + x);
    //    }

    //    static double SeriesSum(double x)
    //    {
    //        double S = 0.0;
    //        double term;
    //        int n = 1;

    //        do
    //        {
    //            term = Math.Pow(-1, n - 1) * (1 + Math.Pow(2, n)) * (Math.Pow(x, n) / n);
    //            S += term;
    //            n++;
    //        } while (Math.Abs(term) >= 1e-6);

    //        return S;
    //    }

    //    static void Main(string[] args)
    //    {
    //        double[] xValues = { 0.1, 0.5, 1.0, 2.0 };

    //        Console.WriteLine("x\tS(x)\ty(x)");

    //        foreach (double x in xValues)
    //        {
    //            double S_value = SeriesSum(x);
    //            double y_value = y(x);
    //            Console.WriteLine($"{x:F2}\t{S_value:F6}\t{y_value:F6}");
    //        }
    //    }
    //}


    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ласкаво просимо до гри 'Вгадай число'!");
            int totalScore = 0;

            totalScore += PlayLevel(1, 10, 3, 5);
            totalScore += PlayLevel(2, 100, 2, 10);

            Console.WriteLine($"Ваш загальний рахунок: {totalScore}");
        }

        static int PlayLevel(int level, int maxNumber, int rounds, int pointsMultiplier)
        {
            int lives = level == 1 ? maxNumber / 2 : maxNumber / 4;
            int score = 0;

            Console.WriteLine($"\n--- Рівень {level} ---");
            Console.WriteLine($"Діапазон: 1 до {maxNumber}. Життя: {lives}");

            for (int round = 1; round <= rounds; round++)
            {
                int numberToGuess = new Random().Next(1, maxNumber + 1);
                Console.WriteLine($"\nРаунд {round}: Загадане число від 1 до {maxNumber}.");

                while (lives > 0)
                {
                    Console.Write("Введіть ваше число: ");
                    int userGuess = int.Parse(Console.ReadLine());

                    if (userGuess == numberToGuess)
                    {
                        Console.WriteLine("Ви вгадали число!");
                        score += lives * pointsMultiplier;
                        break;
                    }
                    else
                    {
                        lives--;
                        Console.WriteLine($"Неправильно! Залишилося життів: {lives}");

                        if (lives > 0)
                        {
                            Console.Write("Бажаєте отримати підказку? (y/n): ");
                            char hintChoice = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            if (hintChoice == 'y')
                            {
                                lives--;
                                if (userGuess < numberToGuess)
                                    Console.WriteLine("Загадане число більше.");
                                else
                                    Console.WriteLine("Загадане число менше.");
                            }
                        }
                    }
                }

                if (lives == 0)
                {
                    Console.WriteLine("На жаль, ви програли в цьому раунді.");
                    break;
                }

                lives = level == 1 ? maxNumber / 2 : maxNumber / 4;
            }

            return score;
        }
    }

}
