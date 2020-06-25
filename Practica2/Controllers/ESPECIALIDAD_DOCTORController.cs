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
    public class ESPECIALIDAD_DOCTORController : Controller
    {
        private DataBase db = new DataBase();

        // GET: ESPECIALIDAD_DOCTOR
        public ActionResult Index()
        {
            var eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Include(e => e.DOCTOR).Include(e => e.ESPECIALIDAD);
            return View(eSPECIALIDAD_DOCTOR.ToList());
        }

        // GET: ESPECIALIDAD_DOCTOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Find(id);
            if (eSPECIALIDAD_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD_DOCTOR);
        }

        // GET: ESPECIALIDAD_DOCTOR/Create
        public ActionResult Create()
        {
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre");
            ViewBag.idEspecialidad = new SelectList(db.ESPECIALIDAD, "id", "nombre");
            return View();
        }

        // POST: ESPECIALIDAD_DOCTOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idEspecialidad,idDoctor")] ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.ESPECIALIDAD_DOCTOR.Add(eSPECIALIDAD_DOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", eSPECIALIDAD_DOCTOR.idDoctor);
            ViewBag.idEspecialidad = new SelectList(db.ESPECIALIDAD, "id", "nombre", eSPECIALIDAD_DOCTOR.idEspecialidad);
            return View(eSPECIALIDAD_DOCTOR);
        }

        // GET: ESPECIALIDAD_DOCTOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Find(id);
            if (eSPECIALIDAD_DOCTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", eSPECIALIDAD_DOCTOR.idDoctor);
            ViewBag.idEspecialidad = new SelectList(db.ESPECIALIDAD, "id", "nombre", eSPECIALIDAD_DOCTOR.idEspecialidad);
            return View(eSPECIALIDAD_DOCTOR);
        }

        // POST: ESPECIALIDAD_DOCTOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idEspecialidad,idDoctor")] ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSPECIALIDAD_DOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", eSPECIALIDAD_DOCTOR.idDoctor);
            ViewBag.idEspecialidad = new SelectList(db.ESPECIALIDAD, "id", "nombre", eSPECIALIDAD_DOCTOR.idEspecialidad);
            return View(eSPECIALIDAD_DOCTOR);
        }

        // GET: ESPECIALIDAD_DOCTOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Find(id);
            if (eSPECIALIDAD_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD_DOCTOR);
        }

        // POST: ESPECIALIDAD_DOCTOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESPECIALIDAD_DOCTOR eSPECIALIDAD_DOCTOR = db.ESPECIALIDAD_DOCTOR.Find(id);
            db.ESPECIALIDAD_DOCTOR.Remove(eSPECIALIDAD_DOCTOR);
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
