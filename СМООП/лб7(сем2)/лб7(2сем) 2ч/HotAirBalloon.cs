using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class HotAirBalloon : Device
    {
        public HotAirBalloon(string name) : base(name, false) { }

        public override string GetDescription()
        {
            return $"Hot Air Balloon: {Name}";
        }
    }
}
