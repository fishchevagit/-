using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    public class Operation : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public long OwnerId { get; set; }
        #region IEntity
        public string TableName => "[dbo].[Operatio]";
        public string[] Colimns => new string[] {  "[Name]", "[OwnerId]" };
        public string SerialData => $"N'{Name}',{OwnerId}";
        #endregion

    }
}
