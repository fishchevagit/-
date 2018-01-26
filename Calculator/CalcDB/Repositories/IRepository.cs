using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IRepository
    {
        OperationResult Get(long Id);

        void Save(OperationResult result);

        void Delete(long Id);

        IList<OperationResult> GetByOperation(long Id);

        IList<OperationResult> GetAll();
    }
}