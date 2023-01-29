using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class QuestDBController : Controller
    {
        // GET: QuestDB
        public ActionResult Index()
        {
            return View();
        }

        public async Task TestQuest()
        {
            var connectionString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
            NpgsqlDataSource dataSource = NpgsqlDataSource.Create(connectionString);

            // Insert some data
            using (var cmd = dataSource.CreateCommand("INSERT INTO data (some_field) VALUES ($1)"))
            {
                cmd.Parameters.AddWithValue("Hello world");
                await cmd.ExecuteNonQueryAsync();
            }

            // Retrieve all rows
            using (var cmd = dataSource.CreateCommand("SELECT some_field FROM data"))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
}