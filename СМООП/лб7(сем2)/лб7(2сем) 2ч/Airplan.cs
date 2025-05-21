using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class Airplane : Device, IEngine
    {
        public int HorsePower { get; set; }

        public Airplane(string name, int horsePower) : base(name, true)
        {
            HorsePower = horsePower;
        }

        public override string GetDescription()
        {
            return $"Airplane: {Name}, HorsePower: {HorsePower}";
        }

        public int GetHorsePower()
        {
            return HorsePower;
        }
    }
}
