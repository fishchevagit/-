using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public interface IOperationResult
    {
        /// <summary>
        /// Результат операции
        /// </summary>
        double Result { get; set; }

        string Error { get; set; }
    }
}
