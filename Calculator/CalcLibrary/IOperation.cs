using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    /// <summary>
    /// Jgthfwbz
    /// </summary>
    public interface IOperation
    {
        string Name { get;  }
        /// <summary>
        /// Выполнить операцию с входными значениями
        /// </summary>
        /// <param name="args">Входные параметры</param>
        /// <returns>Результат</returns>
        IOperationResult Exec(string[] args);
    }
}
