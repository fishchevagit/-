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
    public class OperResultRepository : IRepository
    {
        // todo - вынести в настройки
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\kursi\20170122\калькулятор\Calculator\CalcDB\AppData\CalcDB.mdf;Integrated Security=True";

        public void Delete(long Id)
        {
            string queryString =
                "delete from [dbo].[OperationResult] " +
                $"where id ={Id}; ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                // Do work here; connection closed on following line.
                var count = command.ExecuteNonQuery();

            }
            throw new NotImplementedException();
        }

        public OperationResult Get(long Id)
        {
            OperationResult or = null;
            string queryString = "select  [Id], [OperationId], [Args], [Result], [ExecutionTime], [CreationDate], [Error] from [dbo].[OperationResult]" +
                $"where [Id] = {Id};";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                // Do work here; connection closed on following line.
                var count = command.ExecuteNonQuery();
                // https://docs.microsoft.com/ru-ru/dotnet/framework/data/adonet/retrieving-data-using-a-datareader
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqldatareader(v=vs.110).aspx#%D0%9F%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D1%8B
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqlcommand(v=vs.110).aspx#%D0%9F%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D1%8B
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqlconnection(v=vs.110).aspx#%D0%9A%D0%BE%D0%BC%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%80%D0%B8%D0%B8
                SqlDataReader reader = command.ExecuteReader();
                
                try
                {
                    if (reader.Read())
                    {
                         or = new OperationResult()
                        {
                             Id = (long)reader[0],
                             OperationId = (long)reader[1],
                             Args = reader[2] as string,
                             Result = reader[3] as double?,
                             ExecutionTime = (long)reader[4],
                             CreationDate =  (DateTime)reader[5],
                             Error = reader[6] as string
                        };
                       
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return or;
        }

        public IList<OperationResult> GetAll()
        {
            IList<OperationResult> listOperationResult = new List<OperationResult>();
            string queryString = "select  [Id], [OperationId], [Args], [Result], [ExecutionTime], [CreationDate], [Error] from [dbo].[OperationResult];";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                // Do work here; connection closed on following line.
                var count = command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var or = new OperationResult()
                        {
                            Id = (long)reader[0],
                            OperationId = (long)reader[1],
                            Args = reader[2] as string,
                            Result = reader[3] as double?,
                            ExecutionTime = (long)reader[4],
                            CreationDate = (DateTime)reader[5],
                            Error = reader[6] as string
                        };
                        listOperationResult.Add(or);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return listOperationResult;
        }

        public IList<OperationResult> GetByOperation(long Id)
        {
            IList<OperationResult> listOperationResult = new List<OperationResult>();

            string queryString = "select  [Id], [OperationId], [Args], [Result], [ExecutionTime], [CreationDate], [Error] from [dbo].[OperationResult]"+
                $"where [OperationId] = {Id};";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                // Do work here; connection closed on following line.
                var count = command.ExecuteNonQuery();
                // https://docs.microsoft.com/ru-ru/dotnet/framework/data/adonet/retrieving-data-using-a-datareader
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqldatareader(v=vs.110).aspx#%D0%9F%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D1%8B
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqlcommand(v=vs.110).aspx#%D0%9F%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D1%8B
                //https://msdn.microsoft.com/ru-ru/library/system.data.sqlclient.sqlconnection(v=vs.110).aspx#%D0%9A%D0%BE%D0%BC%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%80%D0%B8%D0%B8
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var or = new OperationResult()
                        {
                            Id = (long)reader[0],
                            OperationId = (long)reader[1],
                            Args = reader[2] as string,
                            Result = reader[3] as double?,
                            ExecutionTime = (long)reader[4],
                            CreationDate = (DateTime)reader[5],
                            Error = reader[6] as string
                        };
                        listOperationResult.Add(or);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return listOperationResult;
        }

        public void Save(OperationResult result)
        {
            string queryString =
                "INSERT INTO [dbo].[OperationResult] " +
                "(OperationId, [Args], [Result], [Error], [ExecutionTime], [CreationDate]) " +
                $"VALUES({result.OperationId}, N'{result.Args}', {result.Result?.ToString(CultureInfo.InvariantCulture)}, N'{result.Error}', {result.ExecutionTime}, GETDATE()); ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                // Do work here; connection closed on following line.
                var count = command.ExecuteNonQuery();

            }
        }
    }
}