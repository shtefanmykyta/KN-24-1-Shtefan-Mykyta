using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class FlyingCarpet : Device
    {
        public FlyingCarpet(string name) : base(name, false) { }

        public override string GetDescription()
        {
            return $"Flying Carpet: {Name}";
        }
    }
}
