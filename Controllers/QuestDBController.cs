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
using System.Collections;
using WebApplication2.Models;
using Org.BouncyCastle.Crypto.Tls;

namespace WebApplication2.Controllers
{
    public class QuestDBController : Controller
    {
        
        // GET: QuestDB
        public ActionResult Index()
        {
            return View(QuestDBWireProtocolSelect());
        }

        //public ActionResult Create([Bind(Include = "Datetime,Name,Flow,FlowSetpoint,Pressure,PressureSetpoint,OverloadValue,OperationStatus,OperationType,OperationMode")] YardMachineMaterial yardMachineMaterial)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.YardMachineMaterial.Add(yardMachineMaterial);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(yardMachineMaterial);
        //}
        public ActionResult Create([Bind(Include = "Datetime,Name,Flow,FlowSetpoint,Pressure,PressureSetpoint,OverloadValue,OperationStatus,OperationType,OperationMode")] QuestDB_MachineModel machine)
        {
            if(ModelState.IsValid == false)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Erro Modelo não é valido, volte a página');</script>");
            }
            QuestDBWireProtocolInsert(machine);
            return View();
        }

        /// <summary>
        /// funcionou
        /// </summary>
        /// <returns></returns>
        public List<QuestDB_MachineModel> QuestDBWireProtocolSelect()
        {

            string username = "admin";
            string password = "quest";
            string database = "questdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";

            var dataSource = NpgsqlDataSource.Create(connectionString);
            object result = null;

            List<QuestDB_MachineModel> listmachine = new List<QuestDB_MachineModel>();
            QuestDB_MachineModel machine = new QuestDB_MachineModel();
            //listmachine[0] = new QuestDB_MachineModel();
            using (var cmd = dataSource.CreateCommand("SELECT * FROM 'questdb-query-1675076348034.csv' LIMIT 100"))
            using (var reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    machine = new QuestDB_MachineModel();
                    machine.Datetime = (reader.GetString(0));
                    machine.PeriodStart = (reader.GetDateTime(1));
                    machine.Name = (reader.GetString(2));
                    machine.Flow = (reader.GetDouble(3));
                    machine.FlowSetpoint = (reader.GetDouble(4));
                    machine.Pressure = (reader.GetDouble(5));
                    machine.PressureSetPoint = (reader.GetDouble(6));
                    machine.OverloadValue = (reader.GetDouble(7));
                    machine.OperationStatus = (reader.GetDouble(8));
                    machine.OperationType = (reader.GetDouble(9));
                    machine.OperationMode = (reader.GetDouble(10));

                    listmachine.Add(machine);
                }
            }
            return listmachine;
        }
        public ActionResult QuestDBWireProtocolInsert(QuestDB_MachineModel machine)
        {
            string username = "admin";
            string password = "quest";
            string database = "qdb";
            int port = 8812;
            var connectionString = $@"host=localhost;port={port};username={username};password={password};database={database};ServerCompatibilityMode=NoTypeLoading;";
            var dataSource = NpgsqlDataSource.Create(connectionString);

            var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=localhost;Username=admin;Password=quest");

            dataSource = dataSourceBuilder.Build();
            int a = 1;
            using (var cmd = dataSource.CreateCommand("INSERT INTO QuestTeste (ID) VALUES ($" + a + ")"))
            {
                cmd.Parameters.AddWithValue(1);
                cmd.ExecuteNonQuery();
                return Content("<script language='javascript' type='text/javascript'>alert(" + cmd.ToString() + ");</script>");
            }
            

            //// Retrieve all rows
            //using (var cmd = dataSource.CreateCommand("SELECT ID FROM QuestTeste"))


            //using (DbConnection conn = new NpgsqlConnection(connectionString))
            //{
            //    conn.Open();
            //    using (DbCommand command = conn.CreateCommand())
            //    {
            //        cmd.Parameters.AddWithValue(1);
            //        cmd.ExecuteNonQuery();
            //        return Content("<script language='javascript' type='text/javascript'>alert("+ " " + ");</script>");
            //    }
            //}
            //return null;
        }
    }
}