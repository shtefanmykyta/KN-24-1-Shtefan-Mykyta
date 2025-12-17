using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ3_СМООП_
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.Json;
    using System.Xml.Serialization;

    [Serializable]
    public class Route
    {
        public string StartPoint { get; set; }        
        public string EndPoint { get; set; }          
        public int IntermediateStops { get; set; }    
        public double AverageTravelTime { get; set; } 
        public int RouteNumber { get; set; }          

        public Route() { }

        public Route(string start, string end, int stops, double time, int number)
        {
            StartPoint = start;
            EndPoint = end;
            IntermediateStops = stops;
            AverageTravelTime = time;
            RouteNumber = number;
        }

        public override string ToString()
        {
            return $"Маршрут №{RouteNumber}: {StartPoint} -> {EndPoint}, " +
                   $"зупинок: {IntermediateStops}, час: {AverageTravelTime} год";
        }
    }

}
