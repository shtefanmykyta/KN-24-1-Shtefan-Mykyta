namespace ЛБ3_СМООП_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProgramLab3
    {
        static void Main()
        {
            List<Route> routes = new List<Route>
        {
            new Route("Кременчук", "Полтава", 3, 2.0, 101),
            new Route("Кременчук", "Київ", 5, 4.5, 102),
            new Route("Кременчук", "Харків", 4, 3.5, 103),
            new Route("Полтава", "Київ", 2, 2.2, 104),
            new Route("Кременчук", "Дніпро", 2, 3.0, 105),
        };

            Console.Write("Кінцевий пункт (LINQ): ");
            string end = Console.ReadLine();
            Console.Write("Максимальний час (год): ");
            double maxTime = double.Parse(Console.ReadLine() ?? "0");

            var query1 = routes
                .Where(r => r.EndPoint.Equals(end, StringComparison.OrdinalIgnoreCase)
                            && r.AverageTravelTime <= maxTime);

            Console.WriteLine("\nМаршрути, що задовольняють умову (LINQ):");
            foreach (var r in query1)
                Console.WriteLine(r);

            var query2 = routes.OrderBy(r => r.AverageTravelTime);
            Console.WriteLine("\nУсі маршрути, відсортовані за часом:");
            foreach (var r in query2)
                Console.WriteLine(r);

            var query3 = routes.GroupBy(r => r.EndPoint);
            Console.WriteLine("\nГрупування за кінцевим пунктом:");
            foreach (var group in query3)
            {
                Console.WriteLine($"Кінцевий пункт: {group.Key}");
                foreach (var r in group)
                    Console.WriteLine("  " + r);
            }

            double avgTime = routes.Average(r => r.AverageTravelTime);
            Console.WriteLine($"\nСередній час подорожі по всіх маршрутах: {avgTime} год");

            Console.ReadLine();
        }
    }

}
