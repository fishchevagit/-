using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    class Program
    {
        static bool IsBinary(string oper)
        {
            if (oper == "sqrt")
                return false;
            return true;
        }
        static bool IsValidOperation(string oper)
        {
            if (oper == "sum" || oper == "sub" || oper == "mul" || oper == "div" ||
                oper == "pow" || oper == "sqrt")
                return true;
            return false;
        }
        static int inputArg(out string oper, out double x, out double y)
        {
            Console.WriteLine("Operations: sum, sub, mul, div, pow, sqrt");
            Console.WriteLine("Please, choose the one");
            oper = Console.ReadLine();
            if (!IsValidOperation(oper))
            {
                Console.WriteLine("Unknown operation!");
                //Console.ReadKey();
                x = 0;
                y = 0;
                return -1;
            }
            
            Console.WriteLine("Enter the arguments.");
            
            string[] ArgStr = Console.ReadLine().Split(' ');
            y = 0;
            if (!Double.TryParse(ArgStr[0], out x))
            {
                Console.WriteLine("The arguments must be numbers");
                //Console.ReadKey();
                return -1;
            }
            if (ArgStr.Length != 1 && !IsBinary(oper))
            {
                Console.WriteLine("Unary operation: one opearand expected!");
                //Console.ReadKey();
                return -1;
            }
            
            if (ArgStr.Length != 2 && IsBinary(oper))
            {
                Console.WriteLine("Binary operation: two opearands expected!");
                //Console.ReadKey();
                return -1;
            }
            /*if (oper == "sqrt")
            {
                 return 1;
            } */           
            else if (!Double.TryParse(ArgStr[1], out y))
            {
                Console.WriteLine("The arguments must be numbers");
                //Console.ReadKey();
                return -1;
            }
            return 1;
        }
        static void Main(string[] args)
        {
            string oper;
            double x = 0;
            double y = 0;
            //calc.exe sum 1 2
            if (args.Length !=0)
            {
                oper = args[0];
                if (!Double.TryParse(args[1], out x) || !Double.TryParse(args[2], out y))
                {
                    Console.WriteLine("The arguments must be numbers");
                    int res = 0; 
                    do
                    {
                        res = inputArg(out oper, out x, out y);
                        if (res == -1)
                        {
                            Console.WriteLine("Error detected. Press anywhere to try again or esc to exit.");
                            ConsoleKeyInfo s = Console.ReadKey();
                            if (s.Key == ConsoleKey.Escape)
                                return;
                        }
                        
                    } while (res == -1);
                }
            }
            else
            {
                inputArg(out oper, out x, out y);
            }
            double rez = 0.0;
            Calc calc = new Calc();
            switch (oper)
            {
                case "sum": rez = calc.Sum(x, y); break;
                case "sub": rez = calc.Sub(x, y); break;
                case "mul": rez = calc.Mul(x, y); break;
                case "div": rez = calc.Div(x, y); break;
                case "pow": rez = calc.Pow(x, y); break;
                case "sqrt": rez = calc.Sqrt(x); break;
                //Console.WriteLine($"sum {x} {y} = {x + y}");
                //        default;
            }
            Console.WriteLine(rez.ToString());
            Console.ReadKey();
        }
    }
}
