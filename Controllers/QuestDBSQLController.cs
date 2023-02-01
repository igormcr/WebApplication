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
        // GET: QuestDBSQL
        public ActionResult Index()
        {
            object result = TestConnectSQL();
            return View();
        }



        // GET: QuestDBSQL/Details/5
        public ActionResult Details(int id)
        {
            SqlCommand com = new SqlCommand("SELECT Body FROM Messages WHERE MessageID = @MessageId");
            com.Parameters.AddWithValue("@MessageId", 1); //Replace 1 with messageid you want to get
            string s = com.ExecuteScalar().ToString();

            return View();
        }

        // GET: QuestDBSQL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestDBSQL/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestDBSQL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestDBSQL/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestDBSQL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestDBSQL/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
