using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб6_2сем_
{
    using System;

    public class RightTriangle : PairOfNumbers
    {
        public RightTriangle(double cathetus1, double cathetus2) : base(cathetus1, cathetus2) { }

        public double Hypotenuse()
        {
            return Math.Sqrt(Math.Pow(base.number1, 2) + Math.Pow(base.number2, 2));
        }

        public double Area()
        {
            return 0.5 * base.number1 * base.number2;
        }

        public override string ToString()
        {
            return $"Right Triangle: Cathetus1 = {base.number1}, Cathetus2 = {base.number2}, " +
                   $"Hypotenuse = {Hypotenuse()}, Area = {Area()}";
        }
    }

}
