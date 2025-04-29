namespace лб6_2сем_
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PairOfNumbers[] pairs = new PairOfNumbers[]
            {
            new PairOfNumbers(3.0, 4.0),
            new RightTriangle(3.0, 4.0),
            new RightTriangle(5.0, 12.0)
            };

            foreach (var pair in pairs)
            {
                Console.WriteLine(pair.ToString());
                Console.WriteLine($"Product: {pair.Product()}");
                Console.WriteLine();
            }

            var firstPair = new PairOfNumbers(3.0, 4.0);
            var secondPair = new PairOfNumbers(3.0, 4.0);
            Console.WriteLine($"Are the two pairs equal? {firstPair.Equals(secondPair)}");
            Console.WriteLine($"Hash Code of first pair: {firstPair.GetHashCode()}");
            Console.WriteLine($"Hash Code of second pair: {secondPair.GetHashCode()}");
        }
    }

}
