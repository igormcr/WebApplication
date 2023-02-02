using Npgsql;
using InfluxDB;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace WebApplication2.Controllers
{
    public class QuestDBController : Controller
    {
        
        // GET: QuestDB
        public ActionResult Index()
        {
            object model = new object();
            model = QuestDBWireProtocolSelect();
            return View(model);
        }

        /// <summary>
        /// funcionou
        /// </summary>
        /// <returns></returns>
        public object QuestDBWireProtocolSelect()
        {

            string username = "admin";
            string password = "quest";
            string database = "questdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";

            var dataSource = NpgsqlDataSource.Create(connectionString);
            object result = null;



            var cmd = dataSource.CreateCommand("SELECT * FROM 'questdb-query-1675076348034.csv' LIMIT 50");
            var reader = cmd.ExecuteReader();
  

            return reader;
            
        }
        public Task QuestDBWireProtocolInsert()
        {
            string username = "admin";
            string password = "quest";
            string database = "qdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";
            var dataSource = NpgsqlDataSource.Create(connectionString);

            var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=localhost;Username=admin;Password=quest");

            dataSource = dataSourceBuilder.Build();

            using (var cmd = dataSource.CreateCommand("INSERT INTO QuestTeste (ID) VALUES ($1)"))
            {
                cmd.Parameters.AddWithValue(1);
                cmd.ExecuteNonQueryAsync();
                Console.Write(cmd.ToString());
            }

            // Retrieve all rows
            using (var cmd = dataSource.CreateCommand("SELECT ID FROM QuestTeste"))


            using (DbConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue(1);
                    cmd.ExecuteNonQueryAsync();
                    Console.Write(cmd.ToString()); // etc
                }
            }

            return null;
        }
    }
}