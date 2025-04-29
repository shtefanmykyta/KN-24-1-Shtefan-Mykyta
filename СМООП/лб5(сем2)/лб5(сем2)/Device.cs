namespace лб5_сем2_
{
    using System;

    namespace ConsoleApp
    {
        public class Device
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public DateTime ReleaseDate { get; set; }
            public Device(string name, double price, DateTime releaseDate)
            {
                Name = name;
                Price = price;
                ReleaseDate = releaseDate;
            }
            public Device() : this("Default Device", 0.0, DateTime.Now) { }
            public override string ToString()
            {
                return $"{Name}, Price: {Price}, Released: {ReleaseDate.ToShortDateString()}";
            }
        }
    }

}
