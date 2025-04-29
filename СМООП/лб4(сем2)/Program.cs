namespace лб4_сем2_
{
    using System;
    using System.Text.RegularExpressions;

    //class Program
    //{
    //    static void Main()
    //    {
    //        string input = "abcdefghijklmnopqrstuv18340";
    //        string pattern = @"^abcdefghijklmnopqrstuv18340$";
    //        bool isMatch = Regex.IsMatch(input, pattern);
    //        if (isMatch)
    //        {
    //            Console.WriteLine("Рядок є правильним.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Рядок є невірним.");
    //        }
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        string[] testDates = {
    //        "29/02/2000",
    //        "30/04/2003",
    //        "01/01/2003",
    //        "29/02/2001",
    //        "30-04-2003",
    //        "1/1/1899"
    //    };
    //        string pattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/(16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31)d{2}$";

    //        foreach (var date in testDates)
    //        {
    //            bool isMatch = Regex.IsMatch(date, pattern);
    //            if (isMatch)
    //            {
    //                string[] parts = date.Split('/');
    //                int day = int.Parse(parts[0]);
    //                int month = int.Parse(parts[1]);
    //                int year = int.Parse(parts[2]);
    //                if ((month == 2 && day > 29) ||
    //                    (month == 2 && day == 29 && !IsLeapYear(year)) ||
    //                    (month == 4 || month == 6 || month == 9 || month == 11) && day > 30 ||
    //                    (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day > 31)
    //                {
    //                    isMatch = false;
    //                }
    //            }
    //            Console.WriteLine($"{date}: {(isMatch ? "Правильна дата" : "Неправильна дата")}");
    //        }
    //    }
    //    static bool IsLeapYear(int year)
    //    {
    //        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    //    }
    //}

    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Виберіть спосіб введення тексту:");
            Console.WriteLine("1. Ввести з клавіатури");
            Console.WriteLine("2. Прочитати з файлу");

            string input = Console.ReadLine();
            string text;

            if (input == "1")
            {
                Console.WriteLine("Введіть текст:");
                text = Console.ReadLine();
            }
            else if (input == "2")
            {
                Console.WriteLine("Введіть шлях до файлу:");
                string filePath = Console.ReadLine();
                try
                {
                    text = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            var words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(word => $"{word} {word.Length}")
                            .ToArray();
            var sortedWords = InsertionSort(words);
            Console.WriteLine("\nРезультуючі слова з довжинами:");
            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("\nВведіть шлях для збереження результатів у файл:");
            string outputFilePath = Console.ReadLine();
            try
            {
                File.WriteAllLines(outputFilePath, sortedWords);
                Console.WriteLine($"Результати успішно записані у файл: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при запису у файл: {ex.Message}");
            }
        }

        static string[] InsertionSort(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                string key = array[i];
                int j = i - 1;
                while (j >= 0 && String.Compare(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return array;
        }
    }

}
