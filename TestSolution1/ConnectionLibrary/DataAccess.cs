using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestSolution1.Models;
using Dapper;

namespace ConnectionLibrary
{
    public class DataAccess
    {
        //Получение строки подключения к Бд
        internal static IDbConnection Connection => new SqlConnection(Helper.CnnVal("SampleDb"));
        
        // Получить список клиентов
        public List<Client> GetListOfClients()
        {
            using (IDbConnection connection = Connection)
            {
                var k = connection.Query<Client>("select * from Clients").ToList();
                return k;
            }
        }
        //Получить список параметров
        public List<Param> GetListOfParams()
        {
            using (IDbConnection connection = Connection)
            {
                return connection.Query<Param>("select * from dbo.Params").ToList();
            }
        }
        //Получение полной информации
        public List<FullInfo> GetFullInfo()
        {
            using (IDbConnection connection = Connection)
            {
                return connection.Query<FullInfo>("select c.ClientName, p.ParamName from Clients c join Params p on c.ClientId = p.ClientId").ToList();
            }
        }
    }
}
