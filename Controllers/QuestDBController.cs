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
            TestQuest3();
            return View();
        }

        public async Task TestQuest()
        {
            string username = "admin";
            string password = "quest";
            string database = "qdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.OpenAsync();
            NpgsqlDataSource dataSource = NpgsqlDataSource.Create(connectionString);

            // Insert some data
            using (var cmd = dataSource.CreateCommand("INSERT INTO QuestTeste (ID) VALUES ($1)"))
            {
                cmd.Parameters.AddWithValue(1);
                cmd.ExecuteNonQueryAsync();
                Console.Write(cmd.ToString());
            }

            // Retrieve all rows
            using (var cmd = dataSource.CreateCommand("SELECT ID FROM QuestTeste"))
            using (var reader = cmd.ExecuteReaderAsync())
            {
                Console.Write(reader.Status.ToString());
                //while (await reader.ReadAsync())
                //{
                //    Console.WriteLine(reader.GetString(0));
                //}
            }
        }
        public async Task TestQuest2()
        {
            string username = "admin";
            string password = "quest";
            string database = "qdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.OpenAsync();

            var sql = "SELECT x FROM long_sequence(5);";

            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            var reader = command.ExecuteReaderAsync();           
               
            
        }
        public Task TestQuest3()
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