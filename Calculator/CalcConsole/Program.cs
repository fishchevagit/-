using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcConsole;
using CalcLibrary;

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
        static int inputArg(string enabledOperations, out string oper, out double x, out double y)
        {
            Console.WriteLine("Operations: {0}", enabledOperations);
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
            double rez;
            Calc calc = new Calc();


            //calc.exe sum 1 2
            if (args.Length !=0)
            {
                rez = calc.Exec(args[0], new[] { args[1], args[2] });
            }
            else
            {
                string enabledOperations = calc.EnabledOperations();
                Console.WriteLine("Operations: ");
                Console.WriteLine("{0}", enabledOperations);
                Console.WriteLine("Please, choose the one");
                oper = Console.ReadLine();
                if (!calc.IsValidOperation(oper))
                {
                    Console.WriteLine("Unknown operation!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Enter the arguments.");

                string[] ArgStr = Console.ReadLine().Split(' ');
                rez = calc.Exec(oper, ArgStr);
            }
            Console.WriteLine(rez.ToString());
            Console.ReadKey();
        }
    }
}
