using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class YardMachineMaterials1Controller : Controller
    {
        private Teste1Entities1 db = new Teste1Entities1();

        // GET: YardMachineMaterials1
        public ActionResult Index()
        {
            return View(db.YardMachineMaterial.ToList());
        }

        // GET: YardMachineMaterials1/Details/5
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

        // GET: YardMachineMaterials1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YardMachineMaterials1/Create
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

        // GET: YardMachineMaterials1/Edit/5
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

        // POST: YardMachineMaterials1/Edit/5
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

        // GET: YardMachineMaterials1/Delete/5
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

        // POST: YardMachineMaterials1/Delete/5
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
