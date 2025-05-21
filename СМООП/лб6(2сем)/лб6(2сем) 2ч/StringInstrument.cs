using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace лб6_2сем__2ч
{
    public class StringInstrument : MusicalInstrument
    {
        public int NumberOfStrings { get; set; }
        public StringInstrument(string name, int year, int numberOfStrings) : base(name, year)
        {
            NumberOfStrings = numberOfStrings;
        }

        public override string GetDescription()
        {
            return $"String Instrument: {Name}, Year: {Year}, Strings: {NumberOfStrings}";
        }
    }
}
