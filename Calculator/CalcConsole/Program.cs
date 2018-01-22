using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //calc.exe sum 1 2
            var oper = args[0];
            double x = Convert.ToDouble(args[1]);
            double y = Convert.ToDouble(args[2]);
            double rez = 0.0; 
            
            switch (oper)
            {
                case "sum": rez = x + y; break;
                    //Console.WriteLine($"sum {x} {y} = {x + y}");
            //        default;
            }
            Console.WriteLine(rez.ToString());
            Console.ReadKey();
           }
    }
}
