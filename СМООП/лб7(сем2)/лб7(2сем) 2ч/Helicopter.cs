using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public class Helicopter : Device, IEngine
{
    public int HorsePower { get; set; }

    public Helicopter(string name, int horsePower) : base(name, true)
    {
        HorsePower = horsePower;
    }

    public override string GetDescription()
    {
        return $"Helicopter: {Name}, HorsePower: {HorsePower}";
    }

    public int GetHorsePower()
    {
        return HorsePower;
    }
}

}
