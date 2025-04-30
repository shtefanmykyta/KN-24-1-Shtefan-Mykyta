namespace лб1_2сем_
{
    using System;

    //class Program
    //{
    //    static void Main()
    //    {
    //        Console.Write("Write value of m: ");
    //        double m = Convert.ToDouble(Console.ReadLine());

    //        Console.Write("Write value of n: ");
    //        double n = Convert.ToDouble(Console.ReadLine());

    //        Console.Write("Write value of a: ");
    //        double a = Convert.ToDouble(Console.ReadLine());

    //        double aInRadians = a * (Math.PI / 180);

    //        double numerator = Math.Pow(m, 2) - Math.Pow(n, 2);
    //        double denominator = Math.Cos(aInRadians);
    //        double firstPart = numerator / denominator;

    //        double secondPart = Math.Sqrt((4.0 / 3.0) - Math.Pow(Math.Cos(aInRadians), 3));
    //        double result = firstPart * secondPart;
    //        Console.WriteLine($"Result: {result}");
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        double xMin = -2.0;
    //        double xMax = 2.0;
    //        int numberOfValues = 8;
    //        double step = (xMax - xMin) / (numberOfValues - 1);
    //using (StreamWriter writer = new StreamWriter("Lab2.res"))
    //{
    //writer.WriteLine("Function value y = cos²(πx) - 2:");

    //        for (int i = 0; i < numberOfValues; i++)
    //        {
    //            double x = xMin + i * step;
    //            double y = Math.Pow(Math.Cos(Math.PI * x), 2) - 2;

    //            writer.WriteLine($"x = {x:F2}, y = {y:F2}");
    //        }
    //    }
    //Console.WriteLine("Результати виведені в файл Lab2.res");
      //}
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        string[] correctAnswers = { "1", "50", "2", "11", "30", "1", "1" };
    //        int score = 0;

    //        Console.WriteLine("Тест: Перевір свої можливості\n");

    //        string[] questions = {
    //        "1. Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?",
    //        "2. На двох руках десять пальців. Скільки пальців на 10?",
    //        "3. Скільки цифр у дюжині?",
    //        "4. Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?",
    //        "5. Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?",
    //        "6. Скільки цифр 9 в інтервалі 1100?",
    //        "7. Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?"
    //    };

    //        for (int i = 0; i < questions.Length; i++)
    //        {
    //            Console.WriteLine(questions[i]);
    //            Console.Write("Ваша відповідь: ");
    //            string userAnswer = Console.ReadLine();

    //            if (userAnswer == correctAnswers[i])
    //            {
    //                score++;
    //            }
    //        }

    //        Console.WriteLine("\nВаш результат:");
    //        if (score == 7)
    //        {
    //            Console.WriteLine("Геній");
    //        }
    //        else if (score == 6)
    //        {
    //            Console.WriteLine("Ерудит");
    //        }
    //        else if (score == 5)
    //        {
    //            Console.WriteLine("Нормальний");
    //        }
    //        else if (score == 4)
    //        {
    //            Console.WriteLine("Здібності середні");
    //        }
    //        else if (score == 3)
    //        {
    //            Console.WriteLine("Здібності нижче середнього");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Треба відпочити!");
    //        }
    //    }
    //}

    using System.IO;

    class Program
    {
        static void Main()
        {
            string filePath = "input.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                double distanceAB = double.Parse(lines[0]);
                double distanceBC = double.Parse(lines[1]);
                double cargoWeight = double.Parse(lines[2]);
                double tankCapacity = double.Parse(lines[3]);

                if (cargoWeight > 2000)
                {
                    Console.WriteLine("Літак не може підняти такий вантаж.");
                    return;
                }

                double fuelConsumptionPerKm = GetFuelConsumption(cargoWeight);
                if (fuelConsumptionPerKm < 0)
                {
                    Console.WriteLine("Літак не може підняти такий вантаж.");
                    return;
                }

                double totalDistance = distanceAB + distanceBC;
                double totalFuelNeeded = totalDistance * fuelConsumptionPerKm;

                if (totalFuelNeeded <= tankCapacity)
                {
                    Console.WriteLine("Польот можна здійснити без дозаправки.");
                    Console.WriteLine($"Необхідна кількість пального: {totalFuelNeeded} літрів.");
                }
                else
                {
                    double fuelNeededToReachB = distanceAB * fuelConsumptionPerKm;
                    double fuelNeededToReachC = distanceBC * fuelConsumptionPerKm;

                    if (fuelNeededToReachB > tankCapacity)
                    {
                        Console.WriteLine("Неможливо долетіти до пункту B.");
                    }
                    else
                    {
                        double fuelNeededAtB = fuelNeededToReachC - (tankCapacity - fuelNeededToReachB);
                        if (fuelNeededAtB < 0)
                            fuelNeededAtB = 0;

                        Console.WriteLine($"Необхідна кількість пального для дозаправки в пункті B: {fuelNeededAtB} літрів.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: " + ex.Message);
            }
        }
        static double GetFuelConsumption(double weight)
        {
            if (weight <= 500)
                return 1;
            else if (weight <= 1000)
                return 4;
            else if (weight <= 1500)
                return 7;
            else if (weight <= 2000)
                return 9;
            else
                return -1;
        }
    }

}
