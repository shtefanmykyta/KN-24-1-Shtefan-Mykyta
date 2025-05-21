using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public interface IDevice
    {
        string GetDescription();
    }
    public interface IEngine : IDevice
    {
        int GetHorsePower();
    }
}
