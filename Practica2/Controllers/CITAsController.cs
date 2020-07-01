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
    public class CITAsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: CITAs
        public ActionResult Index()
        {
            var cITA = db.CITA.Include(c => c.DOCTOR).Include(c => c.PACIENTE);
            return View(cITA.ToList());
        }

        // GET: CITAs
        public ActionResult bonoAlto()
        {
            long? dpi = 0;
            float bonoMasAlto = 0;
            float bonoDoctor = 0;
            var cita = db.CITA.Include(c => c.DOCTOR).Include(c => c.PACIENTE);
            foreach (CITA item in cita)
            {
                bonoDoctor = 0;
                var doc = db.DOCTOR.Find(item.idDoctor);
                bonoDoctor = doc.sueldo;
                foreach (CITA item2 in cita)
                {
                    if (item2.idDoctor ==item.idDoctor)
                    {
                        bonoDoctor += 100;
                    }

                }
                if (bonoDoctor > bonoMasAlto)
                {
                    bonoMasAlto = bonoDoctor;
                    dpi = item.idDoctor;
                }

            }

            return RedirectToAction("reporte1", "REPORTE", new { dpi, bonoMasAlto });
        }

        public ActionResult pacienteCitasMayor()
        {
            long? dpi = 0;
            int? cantidadCitas = 0;
            int? mayorCitas = 0;
            var cita = db.CITA.Include(c => c.DOCTOR).Include(c => c.PACIENTE);
            foreach (CITA item in cita)
            {
                cantidadCitas = 0;
                foreach (CITA item2 in cita)
                {
                    if (item2.idPaciente == item.idPaciente)
                    {
                        cantidadCitas += 1;
                    }

                }
                if (cantidadCitas > mayorCitas)
                {
                    mayorCitas = cantidadCitas;
                    dpi = item.idPaciente;
                }

            }

            return RedirectToAction("reporte2", "REPORTE", new { dpi, mayorCitas });
        }

        // GET: CITAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // GET: CITAs/Create
        public ActionResult Create()
        {
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre");
            ViewBag.idPaciente = new SelectList(db.PACIENTE, "dpi", "nombre");
            return View();
        }

        // POST: CITAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idPaciente,idDoctor,fecha,motivoCita,costo")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.CITA.Add(cITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", cITA.idDoctor);
            ViewBag.idPaciente = new SelectList(db.PACIENTE, "dpi", "nombre", cITA.idPaciente);
            return View(cITA);
        }

        // GET: CITAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", cITA.idDoctor);
            ViewBag.idPaciente = new SelectList(db.PACIENTE, "dpi", "nombre", cITA.idPaciente);
            return View(cITA);
        }

        // POST: CITAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idPaciente,idDoctor,fecha,motivoCita,costo")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDoctor = new SelectList(db.DOCTOR, "dpi", "nombre", cITA.idDoctor);
            ViewBag.idPaciente = new SelectList(db.PACIENTE, "dpi", "nombre", cITA.idPaciente);
            return View(cITA);
        }

        // GET: CITAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // POST: CITAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CITA cITA = db.CITA.Find(id);
            db.CITA.Remove(cITA);
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
