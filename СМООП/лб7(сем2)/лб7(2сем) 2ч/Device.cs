using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__2ч
{
    public abstract class Device : IDevice
    {
        public string Name { get; set; }
        public bool HasEngine { get; set; }

        protected Device(string name, bool hasEngine)
        {
            Name = name;
            HasEngine = hasEngine;
        }

        public abstract string GetDescription();
        public virtual Device Clone()
        {
            return (Device)this.MemberwiseClone();
        }
    }
}
