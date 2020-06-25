using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica2.Models;

namespace Practica2.Controllers
{
    public class DOCTORsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: DOCTORs
        public ActionResult Index()
        {
            return View(db.DOCTOR);
        }

        public ActionResult Especialidad(int? id)
        {
            var eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Include(e => e.DOCTOR).Include(e => e.ESPECIALIDAD).Where(
                e => e.idDoctor == id);
            return View(eSPECIALIDAD_DOCTOR.ToList());

        }

        // GET: DOCTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR);
        }

        // GET: DOCTORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOCTORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dpi,nombre,direccion,telefono,puesto,sueldo")] DOCTOR dOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.DOCTOR.Add(dOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCTOR);
        }

        // GET: DOCTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR);
        }

        // POST: DOCTORs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dpi,nombre,direccion,telefono,puesto,sueldo")] DOCTOR dOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCTOR);
        }

        // GET: DOCTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR);
        }

        // POST: DOCTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            db.DOCTOR.Remove(dOCTOR);
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
