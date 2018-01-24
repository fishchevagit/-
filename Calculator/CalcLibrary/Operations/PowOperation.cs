using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{
    
    public class PowOperation : NumberOperation
    {
        public override string Name { get { return "pow"; } }

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            var result = args.Count() >= 2
                ? Math.Pow(args.ElementAt(0), args.ElementAt(1))
                : double.NaN;

            return new OperResult(result, null);


        }
    }
}
