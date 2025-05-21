using Microsoft.Win32;
using System;

namespace лб7_2сем__2ч
{
    class Program
    {
        static void Main(string[] args)
        {
            Registry registry = new Registry();

            registry.AddDevice(new Airplane("Boeing 747", 40000));
            registry.AddDevice(new Helicopter("Apache", 2000));
            registry.AddDevice(new HotAirBalloon("Classic Balloon"));
            registry.AddDevice(new DeltaWing("Simple Delta"));
            registry.AddDevice(new FlyingCarpet("Magic Carpet"));

            Console.WriteLine("All Devices:");
            registry.ShowAllDevices();
            Console.WriteLine("\nDevices with Engines:");
            registry.ShowDevicesWithEngines();
            Console.WriteLine("\nNon-Engine Devices:");
            registry.ShowNonEngineDevices();
            Console.WriteLine("\nSorted by Name:");
            registry.SortByName();
            registry.ShowAllDevices();
            Console.WriteLine("\nSorted by Type:");
            registry.SortByType();
            registry.ShowAllDevices();
            var clonedDevices = registry.CloneDevices();
            Console.WriteLine("\nCloned Devices:");

            foreach (var device in clonedDevices)
            {
                Console.WriteLine(device.GetDescription());
            }
        }
    }
}
