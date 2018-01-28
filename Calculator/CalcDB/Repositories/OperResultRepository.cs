using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcDB.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace CalcDB.Repositories
{
    public class OperResultRepository : BaseRepository<OperationResult>
    {
        public IList<OperationResult> GetByOperation(long Id)
        {
            return null;
        }
    }
}