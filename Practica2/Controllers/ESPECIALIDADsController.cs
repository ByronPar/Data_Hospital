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
    public class ESPECIALIDADsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: ESPECIALIDADs
        public ActionResult Index()
        {
            return View(db.ESPECIALIDAD.ToList());
        }

        // GET: ESPECIALIDADs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDADs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESPECIALIDADs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] ESPECIALIDAD eSPECIALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.ESPECIALIDAD.Add(eSPECIALIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDADs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // POST: ESPECIALIDADs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] ESPECIALIDAD eSPECIALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSPECIALIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDADs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // POST: ESPECIALIDADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            db.ESPECIALIDAD.Remove(eSPECIALIDAD);
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
