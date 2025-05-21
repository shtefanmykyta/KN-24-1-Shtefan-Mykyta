using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class DeltaWing : Device
    {
        public DeltaWing(string name) : base(name, false) { }

        public override string GetDescription()
        {
            return $"Delta Wing: {Name}";
        }
    }
}
