namespace ЛБ2_СМООП_
{
        using System;
        using System.Collections.Generic;
        using System.IO;

        [Serializable]
        public class Route
        {
            public string StartPoint { get; set; }
            public string EndPoint { get; set; }
            public int IntermediateStops { get; set; }
            public double AverageTravelTime { get; set; }
            public int RouteNumber { get; set; }

            public Route() { }

            public Route(string start, string end, int stops, double time, int number)
            {
                StartPoint = start;
                EndPoint = end;
                IntermediateStops = stops;
                AverageTravelTime = time;
                RouteNumber = number;
            }

            public override string ToString()
            {
                return $"Маршрут №{RouteNumber}: {StartPoint} -> {EndPoint}, " +
                       $"зупинок: {IntermediateStops}, час: {AverageTravelTime} год";
            }
        }


        public class Task1
        {
            static void Main()
            {
                List<Route> routes = new List<Route>
        {
            new Route("Кременчук", "Полтава", 3, 2.0, 101),
            new Route("Кременчук", "Київ", 5, 4.5, 102),
            new Route("Кременчук", "Харків", 4, 3.5, 103),
        };

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n1 - додати маршрут");
                    Console.WriteLine("2 - змінити маршрут");
                    Console.WriteLine("3 - видалити маршрут");
                    Console.WriteLine("4 - показати всі маршрути");
                    Console.WriteLine("5 - виконати запит (за пунктом і часом)");
                    Console.WriteLine("0 - вихід");
                    Console.Write("Ваш вибір: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddRoute(routes);
                            break;
                        case "2":
                            EditRoute(routes);
                            break;
                        case "3":
                            DeleteRoute(routes);
                            break;
                        case "4":
                            PrintRoutes(routes);
                            break;
                        case "5":
                            QueryRoutes(routes);
                            break;
                        case "0":
                            exit = true;
                            break;
                    }
                }
            }

            static void AddRoute(List<Route> routes)
            {
                Console.Write("Початковий пункт: ");
                string start = Console.ReadLine();
                Console.Write("Кінцевий пункт: ");
                string end = Console.ReadLine();
                Console.Write("Кількість проміжних зупинок: ");
                int stops = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Середній час подорожі (год): ");
                double time = double.Parse(Console.ReadLine() ?? "0");
                Console.Write("Номер маршруту: ");
                int number = int.Parse(Console.ReadLine() ?? "0");

                routes.Add(new Route(start, end, stops, time, number));
            }

            static void EditRoute(List<Route> routes)
            {
                Console.Write("Введіть номер маршруту для редагування: ");
                int number = int.Parse(Console.ReadLine() ?? "0");
                Route route = routes.Find(r => r.RouteNumber == number);
                if (route == null)
                {
                    Console.WriteLine("Маршрут не знайдено.");
                    return;
                }

                Console.Write($"Новий початковий пункт ({route.StartPoint}): ");
                string start = Console.ReadLine();
                Console.Write($"Новий кінцевий пункт ({route.EndPoint}): ");
                string end = Console.ReadLine();
                Console.Write($"Нова кількість зупинок ({route.IntermediateStops}): ");
                string stopsStr = Console.ReadLine();
                Console.Write($"Новий час подорожі ({route.AverageTravelTime}): ");
                string timeStr = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(start)) route.StartPoint = start;
                if (!string.IsNullOrWhiteSpace(end)) route.EndPoint = end;
                if (int.TryParse(stopsStr, out int stops)) route.IntermediateStops = stops;
                if (double.TryParse(timeStr, out double time)) route.AverageTravelTime = time;
            }

            static void DeleteRoute(List<Route> routes)
            {
                Console.Write("Введіть номер маршруту для видалення: ");
                int number = int.Parse(Console.ReadLine() ?? "0");
                Route route = routes.Find(r => r.RouteNumber == number);
                if (route != null)
                {
                    routes.Remove(route);
                    Console.WriteLine("Маршрут видалено.");
                }
                else
                {
                    Console.WriteLine("Маршрут не знайдено.");
                }
            }

            static void PrintRoutes(List<Route> routes)
            {
                Console.WriteLine("\nУсі маршрути:");
                foreach (var r in routes)
                    Console.WriteLine(r);
            }

            static void QueryRoutes(List<Route> routes)
            {
                Console.Write("Введіть кінцевий пункт: ");
                string end = Console.ReadLine();
                Console.Write("Введіть максимальний час (год): ");
                double maxTime = double.Parse(Console.ReadLine() ?? "0");

                List<Route> result = new List<Route>();
                foreach (var r in routes)
                {
                    if (string.Equals(r.EndPoint, end, StringComparison.OrdinalIgnoreCase) &&
                        r.AverageTravelTime <= maxTime)
                    {
                        result.Add(r);
                    }
                }

                Console.WriteLine("\nРезультат запиту:");
                foreach (var r in result)
                    Console.WriteLine(r);

                using (StreamWriter sw = new StreamWriter("routes_query_lab2.txt"))
                {
                    sw.WriteLine($"Кінцевий пункт: {end}, макс. час: {maxTime} год");
                    foreach (var r in result)
                        sw.WriteLine(r.ToString());
                }

                Console.WriteLine("Результат записано у routes_query_lab2.txt");
            }
        }

    
}
