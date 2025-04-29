namespace лб5_сем2_
{
    using System;
    using System.Linq;

    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var computer = new Computer(new Person("Alice", "Smith", new DateTime(1995, 5, 15)), TypeOfWork.Business, "192.168.1.10", new Device[0]);
                Console.WriteLine(computer.ToShortString());
                Console.WriteLine($"Is Home: {computer[TypeOfWork.Home]}");
                Console.WriteLine($"Is Business: {computer[TypeOfWork.Business]}");
                Console.WriteLine($"Is Server: {computer[TypeOfWork.Server]}");

                computer.Owner.FirstName = "Alice";
                computer.Owner.LastName = "Smith";
                computer.Owner.BirthYear = 1995;
                computer.IpAddress = "192.168.1.10";

                Console.WriteLine(computer.ToString());
                computer.AddDevices(new Device("Keyboard", 50.0, new DateTime(2022, 1, 1)),
                                    new Device("Mouse", 25.0, new DateTime(2022, 1, 2)));
                Console.WriteLine(computer.ToString());
                Computer[] computersArray = new Computer[5];
                for (int i = 0; i < computersArray.Length; i++)
                {
                    computersArray[i] = new Computer(new Person($"User{i}", $"Last{i}", new DateTime(2000 + i, 1, 1)), TypeOfWork.Home, $"192.168.1.{i + 20}", new Device[]
                    {
                    new Device($"Device{i}", 100 + i * 10, DateTime.Now)
                    });
                    computersArray[i].AddDevices(new Device($"ExtraDevice{i}", 50 + i * 5, DateTime.Now));
                }

                foreach (var comp in computersArray)
                {
                    Console.WriteLine($"IP: {comp.IpAddress}, Short Info: {comp.ToShortString()}");
                }

                var maxDevicesCount = computersArray.Max(c => c.Devices.Length);
                var computersWithMaxDevices = computersArray.Where(c => c.Devices.Length == maxDevicesCount);

                Console.WriteLine("\nComputers with the maximum number of devices:");
                foreach (var comp in computersWithMaxDevices)
                {
                    Console.WriteLine(comp.ToShortString());
                }

                Console.ReadLine();
            }
        }
    }

}
