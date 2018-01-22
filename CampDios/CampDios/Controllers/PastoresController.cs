using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampDios.Modelos;

namespace CampDios.Controllers
{
    
    public class PastoresController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Pastores
        public ActionResult Index()
        {
            var result = db.Pastores
                .Include(m => m.DetalleGrupo)
                .Include(m => m.Iglesia)
                .Include(m => m.Zona)
                .ToList().
                Select(a => new Pastores_Edad
                {
                    IdPastor = a.IdPastor,
                    Nombres = a.Nombres,
                    Apellidos = a.Apellidos,
                    DUI = a.DUI,
                    NIT = a.NIT,
                    FechaNacimiento = a.FechaNacimiento,
                    //Aqui va la edad 
                    Edad = ComputeAge(a.FechaNacimiento),
                    Direccion = a.Direccion,
                    Direccion1 = a.Direccion1,
                    Direccion2 = a.Direccion2,
                    Email = a.Email,
                    Tel = a.Tel,
                    Cel = a.Cel,
                    Sexo = a.Sexo,
                    IdEstadoCivil = a.EstadoCivil.IdEstado,
                    IdProfesion = a.Profesion.IdProfesion,
                    IdCapacitacion = a.Capacitaciones.IdCapacitacion,
                    IdCorporativo = a.LiderazgoCorporativo.IdCorporativo,
                }).ToList();
            return View(result);
        }

        
        // GET: Pastores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastores pastores = db.Pastores.Find(id);
            if (pastores == null)
            {
                return HttpNotFound();
            }
            return View(pastores);
        }

        // GET: Pastores/Create
        public ActionResult Create()
        {
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre");
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado");
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre");
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio");
            ViewBag.IdRolPastor = new SelectList(db.RolesPastor, "IdRolPastor", "RolPastor");
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1");
            return View();
        }

        // POST: Pastores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPastor,Nombres,Apellidos,DUI,NIT,FechaNacimiento,Direccion,Direccion1,Direccion2,Email,Tel,Cel,Sexo,IdEstadoCivil,IdProfesion,IdCapacitacion,IdRolPastor,IdCorporativo")] Pastores pastores)
        {
            if (ModelState.IsValid)
            {
                db.Pastores.Add(pastores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", pastores.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", pastores.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", pastores.IdCorporativo);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", pastores.IdProfesion);
            ViewBag.IdRolPastor = new SelectList(db.RolesPastor, "IdRolPastor", "RolPastor", pastores.IdRolPastor);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", pastores.Sexo);
            return View(pastores);
        }

        [AuthorizeUserAccesLevel(UserRole = true)]
        // GET: Pastores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastores pastores = db.Pastores.Find(id);
            if (pastores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", pastores.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", pastores.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", pastores.IdCorporativo);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", pastores.IdProfesion);
            ViewBag.IdRolPastor = new SelectList(db.RolesPastor, "IdRolPastor", "RolPastor", pastores.IdRolPastor);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", pastores.Sexo);
            return View(pastores);
        }

        // POST: Pastores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPastor,Nombres,Apellidos,DUI,NIT,FechaNacimiento,Direccion,Direccion1,Direccion2,Email,Tel,Cel,Sexo,IdEstadoCivil,IdProfesion,IdCapacitacion,IdRolPastor,IdCorporativo")] Pastores pastores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pastores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", pastores.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", pastores.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", pastores.IdCorporativo);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", pastores.IdProfesion);
            ViewBag.IdRolPastor = new SelectList(db.RolesPastor, "IdRolPastor", "RolPastor", pastores.IdRolPastor);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", pastores.Sexo);
            return View(pastores);
        }

        // GET: Pastores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastores pastores = db.Pastores.Find(id);
            if (pastores == null)
            {
                return HttpNotFound();
            }
            return View(pastores);
        }

        // POST: Pastores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pastores pastores = db.Pastores.Find(id);
            db.Pastores.Remove(pastores);
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

        //Metodo para calcular la edad de las personas
        private int ComputeAge(DateTime birthdate)
        {
            DateTime ahora = DateTime.Today;
            int edad = ahora.Year - birthdate.Year;
            if (birthdate > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

    }
}
