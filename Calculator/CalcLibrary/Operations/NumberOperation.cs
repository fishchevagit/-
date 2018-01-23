using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{
    public abstract class NumberOperation : IOperation
    {
        public abstract string Name { get; }

        public IOperationResult Exec(string[] args)
        {
            //var numbers = args.Select(   it => Convert.ToDouble(it)     );
            //var result = numbers.Sum();
            var numbers = args.Select(it => Convert.ToDouble(it));

            return Exec(numbers);
        }

        public abstract IOperationResult Exec(IEnumerable<double> numbers);
      
        
    }
}
