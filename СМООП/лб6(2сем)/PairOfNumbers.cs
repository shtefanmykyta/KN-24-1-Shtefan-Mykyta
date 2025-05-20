using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб6_2сем_
{
    public class PairOfNumbers
    {
        protected double number1;
        protected double number2;
        public PairOfNumbers(double num1, double num2)
        {
            number1 = num1;
            number2 = num2;
        }
        public void SetNumbers(double num1, double num2)
        {
            number1 = num1;
            number2 = num2;
        }
        public double Product()
        {
            return number1 * number2;
        }
        public override string ToString()
        {
            return $"Pair: ({number1}, {number2})";
        }
        public override bool Equals(object obj)
        {
            if (obj is PairOfNumbers other)
            {
                return this.number1 == other.number1 && this.number2 == other.number2;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(number1, number2);
        }
    }
}
