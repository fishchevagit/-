using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{
    
    public class SumOperation : NumberOperation
    {
        public override string Name { get { return "sum"; } }

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            return new OperResult(args.Sum(),"");
        }
    }
}
