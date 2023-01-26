using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication2;

namespace WebApplication2.Controllers
{

    public class YardMachineMaterialsController : Controller
    {
        private Teste1Entities1 db = new Teste1Entities1();

        // GET: YardMachineMaterials
        public ActionResult Index()
        {
            var client = new InfluxDBClient("http://192.168.15.115:8086", "HlFomVb-ps9_xv7dLv0dPjQdOiJM_xd-MfyCqyeghsGnWT70NDQttq_BfN8ihftsyJUIn6XfylQcj9YjUBXgjA==");
            List<YardMachineMaterial> listyard =  db.YardMachineMaterial.ToList();
            List<InfluxDB.Client.Writes.PointData> points = new List<InfluxDB.Client.Writes.PointData>(0);
            //object transcriber = new { Name = listyard[i], Flow = listyard[i].Flow };
            var listtotal = db.YardMachineMaterial.ToList().Count;

            using (var writeApi = client.GetWriteApi())
            {
                for (int i2 = 0; i2 < 30; i2++)
                {
                    var minusday = i2;
                    for (int i = 0; i < listtotal; i++)
                    {
                        //if(i2 == 0)
                        //{
                        // var point2 = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        //.Tag("Name", listyard[i].Name)
                        //.Field("Flow", listyard[i].Flow)
                        //.Field("FlowSetpoint", listyard[i].FlowSetpoint)
                        //.Field("Pressure", listyard[i].Pressure)
                        //.Field("PressureSetpoint", listyard[i].PressureSetpoint)
                        //.Field("OverloadValue", listyard[i].OverloadValue)
                        //.Field("OperationStatus", listyard[i].OperationStatus)
                        //.Field("OperationType", listyard[i].OperationType)
                        //.Field("OperationMode", listyard[i].OperationMode)
                        //.Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                        //    points.Add(point2);
                        //}

                        var point = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Name", listyard[i].Name)
                        .Field("Flow", listyard[i].Flow)
                        .Field("FlowSetpoint", listyard[i].FlowSetpoint)
                        .Field("Pressure", listyard[i].Pressure)
                        .Field("PressureSetpoint", listyard[i].PressureSetpoint)
                        .Field("OverloadValue", listyard[i].OverloadValue)
                        .Field("OperationStatus", listyard[i].OperationStatus)
                        .Field("OperationType", listyard[i].OperationType)
                        .Field("OperationMode", listyard[i].OperationMode)
                        .Timestamp(listyard[i].Datetime.ToUniversalTime().AddDays(-minusday), WritePrecision.Ns);

                        writeApi.WritePoint(point, "Teste3", "ec19deabee672945");
                        //points.Add(point);
                    }

                    //writeApi.WritePoints(points, "Teste3", "ec19deabee672945");
                    //points.Clear();
                    //writeApi.Dispose();
                }
            }
            return View(db.YardMachineMaterial.ToList());
        }

        // GET: YardMachineMaterials/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardMachineMaterial yardMachineMaterial = db.YardMachineMaterial.Find(id);
            if (yardMachineMaterial == null)
            {
                return HttpNotFound();
            }
            return View(yardMachineMaterial);
        }

        // GET: YardMachineMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YardMachineMaterials/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Datetime,Name,Flow,FlowSetpoint,Pressure,PressureSetpoint,OverloadValue,OperationStatus,OperationType,OperationMode")] YardMachineMaterial yardMachineMaterial)
        {
            if (ModelState.IsValid)
            {
                db.YardMachineMaterial.Add(yardMachineMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yardMachineMaterial);
        }

        // GET: YardMachineMaterials/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardMachineMaterial yardMachineMaterial = db.YardMachineMaterial.Find(id);
            if (yardMachineMaterial == null)
            {
                return HttpNotFound();
            }
            return View(yardMachineMaterial);
        }

        // POST: YardMachineMaterials/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Datetime,Name,Flow,FlowSetpoint,Pressure,PressureSetpoint,OverloadValue,OperationStatus,OperationType,OperationMode")] YardMachineMaterial yardMachineMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yardMachineMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yardMachineMaterial);
        }

        // GET: YardMachineMaterials/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardMachineMaterial yardMachineMaterial = db.YardMachineMaterial.Find(id);
            if (yardMachineMaterial == null)
            {
                return HttpNotFound();
            }
            return View(yardMachineMaterial);
        }

        // POST: YardMachineMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            YardMachineMaterial yardMachineMaterial = db.YardMachineMaterial.Find(id);
            db.YardMachineMaterial.Remove(yardMachineMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
