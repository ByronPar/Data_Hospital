using Practica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Controllers
{
    public class REPORTEController : Controller
    {
        private DataBase db = new DataBase();
        // GET: REPORTE
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult reporte1(long? dpi, float bonoMasAlto) {
            
            var doctor = db.DOCTOR.Find(dpi);
            ViewBag.bonoTotal = bonoMasAlto.ToString();
            return View(doctor);
        }

        public ActionResult reporte2(long? dpi, int? mayorCitas)
        {
            var paciente = db.PACIENTE.Find(dpi);
            ViewBag.totalCitas = mayorCitas.ToString();
            return View(paciente);
        }





    }
}