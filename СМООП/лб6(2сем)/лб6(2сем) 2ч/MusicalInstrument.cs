using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб6_2сем__2ч
{

    public abstract class MusicalInstrument
    {
        public string Name { get; set; }
        public int Year { get; set; }

        protected MusicalInstrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public abstract string GetDescription();
    }

}
