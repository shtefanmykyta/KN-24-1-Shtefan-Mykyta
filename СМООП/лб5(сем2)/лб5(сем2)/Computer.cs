namespace лб5_сем2_
{
    using System;
    using System.Linq;

    namespace ConsoleApp
    {
        public enum TypeOfWork
        {
            Home,
            Business,
            Server
        }

        public class Computer
        {
            private Person owner;
            private TypeOfWork typeOfWork;
            private string ipAddress;
            private Device[] devices;
            public Computer(Person owner, TypeOfWork typeOfWork, string ipAddress, Device[] devices)
            {
                this.owner = owner;
                this.typeOfWork = typeOfWork;
                this.ipAddress = ipAddress;
                this.devices = devices ?? new Device[0];
            }
            public Computer() : this(new Person(), TypeOfWork.Home, "192.168.1.1", new Device[0]) { }
            public Person Owner
            {
                get => owner;
                set => owner = value ?? throw new ArgumentNullException(nameof(value), "Owner cannot be null");
            }

            public TypeOfWork WorkType
            {
                get => typeOfWork;
                set => typeOfWork = value;
            }

            public string IpAddress
            {
                get => ipAddress;
                set => ipAddress = value ?? throw new ArgumentNullException(nameof(value), "IP Address cannot be null");
            }

            public Device[] Devices
            {
                get => devices;
                set => devices = value ?? throw new ArgumentNullException(nameof(value), "Devices cannot be null");
            }
            public double TotalPrice => devices.Sum(device => device.Price);
            public bool this[TypeOfWork workType] => typeOfWork == workType;
            public void AddDevices(params Device[] newDevices)
            {
                if (newDevices == null) return;

                var currentDevices = devices.ToList();
                currentDevices.AddRange(newDevices);
                devices = currentDevices.ToArray();
            }
            public override string ToString()
            {
                return $"Owner: {owner.ToString()}, Work Type: {typeOfWork}, IP: {ipAddress}, Devices: [{string.Join(", ", devices.Select(d => d.ToString()))}]";
            }
            public string ToShortString()
            {
                return $"Owner: {owner.ToShortString()}, Total Price: {TotalPrice}";
            }
        }
    }

}
