using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class QuestDBSQLController : Controller
    {
        private Teste1Entities1 db = new Teste1Entities1();
        // GET: QuestDBSQL
        public ActionResult Index()
        {
            object result = TestConnectSQL();
            return View();
        }

        public SqlDataReader TestConnectSQL()
        {
            string connStr = "Data Source=.;Initial Catalog=master;Integrated Security=True;";


            string cmdStr = "SELECT * FROM OPENQUERY(QUESTDB,'SELECT * FROM [questdb-query-1675076348034.csv] LIMIT 50000')";

            var conn = new SqlConnection(connStr);

            conn.Open();

            var cmd = new SqlCommand(cmdStr, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            object watcher = dr;

            return dr;


        }

        public ActionResult SelectParaQuestDBviaSQL()
        {
            string connStr = "Data Source=.;Initial Catalog=master;Integrated Security=True;";
            var conn = new SqlConnection(connStr);

            List<YardMachineMaterial> listyard = db.YardMachineMaterial.ToList();
            List<InfluxDB.Client.Writes.PointData> points = new List<InfluxDB.Client.Writes.PointData>(0);

            for (int i2 = 0; i2 < 30; i2++)
            {

                var listtotal = db.YardMachineMaterial.ToList().Count;
                var minusday = i2;
                for (int i = 0; i < listtotal; i++)
                {

                    object transcriber = new { Name = listyard[i], Flow = listyard[i].Flow };

                    string cmdStr = "SELECT * FROM OPENQUERY(QUESTDB,'SELECT * FROM [questdb-query-1675076348034.csv] LIMIT 50000')";

                    var cmd = new SqlCommand(cmdStr, conn);

                    using (var writeApi = cmd.ExecuteReader())
                    {
                        cmd.ExecuteReader();
                    }
                }
            }
            return View(db.YardMachineMaterial.ToList());
        }

        //}
    }
}
