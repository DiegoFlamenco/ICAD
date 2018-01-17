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
    [Authorize]
    public class MiembrosController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Miembros
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Miembros
                .Include(m => m.Capacitaciones)
                .Include(m => m.EstadoCivil)
                .Include(m => m.LiderazgoCorporativo)
                .Include(m => m.Miembros2)
                .Include(m => m.Profesion)
                .Include(m => m.Roles)
                .Include(m => m.Sexo1)
                .ToList().
                Select(a => new Miembros_Edad {
                    IdMiembro = a.IdMiembro,
                    Nombres = a.Nombres,
                    Apellidos = a.Apellidos,
                    DUI = a.DUI,
                    NIT = a.NIT,
                    FechaNacimiento = a.FechaNacimiento,
                    //Aqui va la edad 
                    Edad = ComputeAge(a.FechaNacimiento),
                    Direccion=a.Direccion,
                    Direccion1=a.Direccion1,
                    Direccion2=a.Direccion2,
                    Email=a.Email,
                    Tel=a.Tel,
                    Cel=a.Cel,
                    Sexo=a.Sexo,
                    SexoDescripcion = a.Sexo1.Sexo1,

                    IdEstadoCivil=a.EstadoCivil.IdEstado,
                    NombreEstadoC=a.EstadoCivil.Estado,

                    IdProfesion=a.Profesion.IdProfesion,
                    NombreProfesion=a.Profesion.Oficio,

                    IdCapacitacion=a.Capacitaciones.IdCapacitacion,
                    NombreCapacitacion=a.Capacitaciones.Nombre,

                    IdRol=a.Roles.IdRol,
                    NombreRol=a.Roles.Rol,

                    IdHMayor=a.IdHMayor,
                    NombreHermanoM=a.Miembros2.Nombres,

                    IdCorporativo=a.LiderazgoCorporativo.IdCorporativo,
                    NombreCorporativo=a.LiderazgoCorporativo.Nombre

                   

                }).ToList();
            //var miembros = db.Miembros.Include(m => m.Capacitaciones).Include(m => m.EstadoCivil).Include(m => m.LiderazgoCorporativo).Include(m => m.Miembros2).Include(m => m.Profesion).Include(m => m.Roles).Include(m => m.Sexo1);

            return View(result);
        }

        // GET: Miembros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // GET: Miembros/Create
        public ActionResult Create()
        {
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre");
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado");
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre");
            ViewBag.IdHMayor = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio"); 
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol");
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1");
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre");
            return View();
        }

        // POST: Miembros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMiembro,Nombres,Apellidos,DUI,NIT,FechaNacimiento,Direccion,Direccion1,Direccion2,Email,Tel,Cel,Sexo,IdEstadoCivil,IdProfesion,IdCapacitacion,IdRol,IdHMayor,IdCorporativo,IdIglesia")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                db.Miembros.Add(miembros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", miembros.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", miembros.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", miembros.IdCorporativo);
            ViewBag.IdHMayor = new SelectList(db.Miembros, "IdMiembro", "Nombres", miembros.IdHMayor);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", miembros.IdProfesion);
           
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", miembros.IdRol);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", miembros.Sexo);
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre", miembros.IdIglesia);
            return View(miembros);
        }

        // GET: Miembros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", miembros.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", miembros.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", miembros.IdCorporativo);
            ViewBag.IdHMayor = new SelectList(db.Miembros, "IdMiembro", "Nombres", miembros.IdHMayor);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", miembros.IdProfesion);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", miembros.IdRol);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", miembros.Sexo);
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre", miembros.IdIglesia);
            return View(miembros);
        }

        // POST: Miembros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMiembro,Nombres,Apellidos,DUI,NIT,FechaNacimiento,Direccion,Direccion1,Direccion2,Email,Tel,Cel,Sexo,IdEstadoCivil,IdProfesion,IdCapacitacion,IdRol,IdHMayor,IdCorporativo,IdIglesia")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitaciones, "IdCapacitacion", "Nombre", miembros.IdCapacitacion);
            ViewBag.IdEstadoCivil = new SelectList(db.EstadoCivil, "IdEstado", "Estado", miembros.IdEstadoCivil);
            ViewBag.IdCorporativo = new SelectList(db.LiderazgoCorporativo, "IdCorporativo", "Nombre", miembros.IdCorporativo);
            ViewBag.IdHMayor = new SelectList(db.Miembros, "IdMiembro", "Nombres", miembros.IdHMayor);
            ViewBag.IdProfesion = new SelectList(db.Profesion, "IdProfesion", "Oficio", miembros.IdProfesion);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", miembros.IdRol);
            ViewBag.Sexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", miembros.Sexo);
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre",miembros.IdIglesia);
            return View(miembros);
        }

        // GET: Miembros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // POST: Miembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembros miembros = db.Miembros.Find(id);
            db.Miembros.Remove(miembros);
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
        private int ComputeAge(DateTime birthdate) {
            DateTime ahora = DateTime.Today;
            int edad = ahora.Year - birthdate.Year;
            if (birthdate > DateTime.Today.AddYears(-edad)) {
                edad--;
            }
            return edad;
        }

        private string getCapacitacionName(Capacitaciones capa) {
            return (capa == null) ? string.Empty : capa.Nombre;
        }
    }
}
