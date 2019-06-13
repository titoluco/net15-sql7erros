using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace MeuTrabalho.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        public string connectionString { get; set; }
        
        public HistoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Log(string mensagem)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(mensagem);
            }
        }
    }
}
