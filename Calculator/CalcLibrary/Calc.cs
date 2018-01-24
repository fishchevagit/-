using CalcLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CalcLibrary
{
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>() ;

            var curAssembly = Assembly.GetExecutingAssembly();

            //операции из текущей сборки
            LoadOperation(curAssembly);

            //операци сторонних разработчиков
            var pathEnvironment = Path.Combine(Environment.CurrentDirectory, "extentions");

            if (Directory.Exists(pathEnvironment))
            {
                var assembliies = Directory.GetFiles(pathEnvironment, "*.dll");

                foreach (var filename in assembliies)
                {
                    LoadOperation(Assembly.LoadFile(filename));
                }
            }

            //var curAssembly = Assembly.LoadFile(@"D:\kursi\20170122\калькулятор\Calculator\CalcConsole\bin\Debug\extentions\exit.calculator.finance.dll");

            //LoadOperation(curAssembly);

        }
        private void LoadOperation(Assembly curAssembly)
        {
            var types = curAssembly.GetTypes();
            var typeOperation = typeof(IOperation);

            foreach (var type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;

                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeOperation))
                {
                    var obj = Activator.CreateInstance(type) as IOperation;
                    if (obj != null)
                        Operations.Add(obj);
                }
            }

            /*var sumType = typeof(SumOperation);
            sumType.GetMethods();
            sumType.GetInterfaces();*/
        }

        private IList<IOperation> Operations;

        public bool IsValidOperation(string operationName)
        {
            return Operations.FirstOrDefault(it => it.Name == operationName) != null;
        }
        public string EnabledOperations()
        {
            StringBuilder sb = new StringBuilder();
            //Operations.Select(it => (it.Name));
            foreach (var oper in Operations)
            {
                sb.AppendFormat("\t{0}\n",oper.Name);
            }
            return sb.ToString();
        }
        public string[] GetOperationName()
        {
            return Operations.Select(it => (it.Name)).ToArray();
        }

        public double Exec(string operationName, string[] args)
        {
            IOperation oper;
            // select top 1 * 
            // from Operations 
            // where Name == operationName

            //it => it.Name == operationName
             /*bool Func(IOperation it, string operationName)
             {
                 return it.Name == operationName;
             }*/

            // найти операцию в списке операций
            oper = Operations.FirstOrDefault(it => it.Name == operationName);
            
            // если не удалось найти - возвращаем NaN
            if (oper == null)
            {
                return double.NaN;
            }

            // иначе
            // вычисляем результат операции
            var result = oper.Exec(args);
            // если в результате ошибка заполнена
            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                // выводим ее на экран
            }
            else
            {
                // иначе выводим результат
                return result.Result;
            }
            //значение по умолчанию
            return double.NaN;
        }
        #region int
        [Obsolete("Не использовать",true)]
        public int Sum(int x, int y)
        {
            return (int)Sum((double)x, (double)y);
        }
        #endregion
        #region double
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
        #endregion
    }
}
