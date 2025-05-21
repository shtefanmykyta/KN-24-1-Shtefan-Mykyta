using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class Registry
    {
        private List<Device> devices;

        public Registry()
        {
            devices = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            devices.Add(device);
        }

        public void ShowAllDevices()
        {
            foreach (var device in devices)
            {
                Console.WriteLine(device.GetDescription());
            }
        }

        public void ShowDevicesWithEngines()
        {
            var devicesWithEngines = devices.Where(d => d.HasEngine).ToList();
            foreach (var device in devicesWithEngines)
            {
                Console.WriteLine(device.GetDescription());
            }
        }

        public void ShowNonEngineDevices()
        {
            var nonEngineDevices = devices.Where(d => !d.HasEngine).ToList();
            foreach (var device in nonEngineDevices)
            {
                Console.WriteLine(device.GetDescription());
            }
        }

        public void SortByName()
        {
            devices = devices.OrderBy(d => d.Name).ToList();
        }

        public void SortByType()
        {
            devices = devices.OrderBy(d => d.GetType().Name).ToList();
        }

        public List<Device> CloneDevices()
        {
            return devices.Select(d => d.Clone()).ToList();
        }
    }
}
