namespace лб8_сем2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //Завдання 1
    public class DelegatesAndMethods
    {
        public static Action DisplayCurrentTime = () =>
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
        };

        public static Action DisplayCurrentDate = () =>
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
        };

        public static Action DisplayCurrentDayOfWeek = () =>
        {
            Console.WriteLine($"Current Day of Week: {DateTime.Now.DayOfWeek}");
        };

        public static Predicate<int> IsPrime = (num) =>
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        };

        public static Predicate<int> IsFibonacci = (n) =>
        {
            if (n <= 1) return true;
            int a = 0;
            int b = 1;
            while (b < n)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }
            return b == n;
        };

        public static Func<double, double, double> CalculateTriangleArea = (baseLength, height) =>
        {
            return 0.5 * baseLength * height;
        };

        public static Func<double, double, double> CalculateRectangleArea = (length, width) =>
        {
            return length * width;
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating methods using delegates:");
            Console.WriteLine("--------------------------------------");

            DisplayCurrentTime();
            DisplayCurrentDate();
            DisplayCurrentDayOfWeek();

            Console.WriteLine();
            int numberToCheck = 17;
            Console.WriteLine($"Is {numberToCheck} prime? {IsPrime(numberToCheck)}");
            numberToCheck = 13;
            Console.WriteLine($"Is {numberToCheck} a Fibonacci number? {IsFibonacci(numberToCheck)}");
            Console.WriteLine();

            double triangleBase = 5;
            double triangleHeight = 10;
            double triangleArea = CalculateTriangleArea(triangleBase, triangleHeight);
            Console.WriteLine($"Area of a triangle with base {triangleBase} and height {triangleHeight}: {triangleArea}");
            double rectangleLength = 7;
            double rectangleWidth = 8;
            double rectangleArea = CalculateRectangleArea(rectangleLength, rectangleWidth);
            Console.WriteLine($"Area of a rectangle with length {rectangleLength} and width {rectangleWidth}: {rectangleArea}");
        }
    }

    //Завдання 2
    public class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Volume: {Volume}";
        }
    }

    public class Valiza
    {
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public double Weight { get; set; }
        public double MaxVolume { get; private set; }
        public List<Item> Contents { get; private set; }
        public double CurrentVolume { get; private set; }

        public delegate void ItemAddedEventHandler(object sender, ItemAddedEventArgs e);
        public event ItemAddedEventHandler ItemAdded;

        public Valiza(double maxVolume)
        {
            MaxVolume = maxVolume;
            Contents = new List<Item>();
            CurrentVolume = 0;
        }

        public void SetColor(string color) => Color = color;
        public void SetManufacturer(string manufacturer) => Manufacturer = manufacturer;
        public void SetWeight(double weight) => Weight = weight;
        public void AddItem(Item item)
        {
            if (CurrentVolume + item.Volume <= MaxVolume)
            {
                Contents.Add(item);
                CurrentVolume += item.Volume;
                OnItemAdded(item);
            }
            else
            {
                throw new InvalidOperationException($"Cannot add item '{item.Name}'. Not enough space in the suitcase. Remaining volume: {MaxVolume - CurrentVolume}, Item volume: {item.Volume}");
            }
        }

        protected virtual void OnItemAdded(Item item)
        {
            ItemAdded?.Invoke(this, new ItemAddedEventArgs(item));
        }
    }

    public class ItemAddedEventArgs : EventArgs
    {
        public Item AddedItem { get; }

        public ItemAddedEventArgs(Item item)
        {
            AddedItem = item;
        }
    }

    public class Example
    {
        public static void Main(string[] args)
        {
            Valiza mySuitcase = new Valiza(50);
            mySuitcase.SetColor("Blue");
            mySuitcase.SetManufacturer("Samsonite");
            mySuitcase.SetWeight(2.5);

            mySuitcase.ItemAdded += MySuitcase_ItemAdded;

            try
            {
                mySuitcase.AddItem(new Item("Shirt", 5));
                mySuitcase.AddItem(new Item("Pants", 7));
                mySuitcase.AddItem(new Item("Shoes", 10));
                mySuitcase.AddItem(new Item("Book", 2));
                mySuitcase.AddItem(new Item("Laptop", 20));
                // This will throw an exception as the total volume will exceed 50
                mySuitcase.AddItem(new Item("Jacket", 10));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine($"\nSuitcase Contents (Total Volume: {mySuitcase.CurrentVolume}/{mySuitcase.MaxVolume}):");
            foreach (var item in mySuitcase.Contents)
            {
                Console.WriteLine($"- {item}");
            }
        }
        private static void MySuitcase_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            Console.WriteLine($"Item '{e.AddedItem.Name}' added to the suitcase.");
        }
    }

    //Завдання 3
    public class LambdaExpressions
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 7, 14, 3, 21, 9, 28 };
            Func<int[], int> countMultiplesOfSeven = arr => arr.Count(n => n % 7 == 0);
            int multiplesOfSevenCount = countMultiplesOfSeven(numbers);
            Console.WriteLine($"Number of multiples of seven: {multiplesOfSevenCount}");

            int[] signedNumbers = { -5, 2, 0, 8, -1, 10 };
            Func<int[], int> countPositiveNumbers = arr => arr.Count(n => n > 0);
            int positiveNumbersCount = countPositiveNumbers(signedNumbers);
            Console.WriteLine($"Number of positive numbers: {positiveNumbersCount}");

            Func<DateTime, bool> isProgrammersDay = date => date.DayOfYear == 256;
            DateTime date1 = new DateTime(2023, 9, 13); // Example: Programmer's Day in 2023
            DateTime date2 = new DateTime(2023, 10, 1);
            Console.WriteLine($"{date1.ToShortDateString()} is Programmer's Day: {isProgrammersDay(date1)}");
            Console.WriteLine($"{date2.ToShortDateString()} is Programmer's Day: {isProgrammersDay(date2)}");

            Func<string, string, bool> containsWord = (text, word) => text.Contains(word, StringComparison.OrdinalIgnoreCase);
            Func<string, string[], bool> containsAnyWord = (text, words) => words.Any(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));

            string textToCheck = "This is a sample text with the word example.";
            Console.WriteLine($"'{textToCheck}' contains 'example': {containsWord(textToCheck, "example")}");
            Console.WriteLine($"'{textToCheck}' contains 'test': {containsWord(textToCheck, "test")}");

            string[] wordsToCheck = { "sample", "text", "another" };
            Console.WriteLine($"'{textToCheck}' contains any of ['{string.Join("', '", wordsToCheck)}']: {containsAnyWord(textToCheck, wordsToCheck)}");
        }
    }
}
