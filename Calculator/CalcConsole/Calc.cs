using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    public class Calc
    {
        public double Sum(double x, double y)
        {
            return x+y;
        }
        public double Sub(double x, double y)
        {
            return x-y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
                return x / y;
            else
                return Double.NaN;
        }
        public double Pow(double x, double y)
        {
            return Math.Pow(x , y);
        }
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }
    }
}
