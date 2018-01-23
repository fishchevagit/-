using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{

    public class SqrtOperation : NumberOperation
    {
        public override string Name { get { return "sqrt"; } }

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            var result =args.Count() >= 1
                   ? Math.Sqrt(args.ElementAt(0))
                   : double.NaN;
            return new OperResult(result, null);
        }
    }
}
