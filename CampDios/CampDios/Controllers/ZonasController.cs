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
    public class ZonasController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Zonas
        public ActionResult Index()
        {
            var zona = db.Zona.Include(z => z.Iglesia).Include(z => z.Miembros);
            return View(zona.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        public ActionResult ComunidadDetalle(int? id)
        {        
            var comunidad = db.Comunidad.Where(c => c.IdZona == id);
            return View(comunidad);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre");
            var result = db.Database.SqlQuery<seleccionar_pastor_zona_Result>("exec seleccionar_pastor_zona"); //llamando al procedimiento almacenado "seleccionar_pastor_zona"
            ViewBag.IdPastorZona = new SelectList(result.ToList(), "IdMiembro", "Nombres");// pasando lo que viene del Stored Procedure a el dropdown
            return View();
        }

        // POST: Zonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZona,Nombre,Descripcion,Direccion,IdPastorZona,IdIglesia")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zona.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre", zona.IdIglesia); 
            ViewBag.IdPastorZona = new SelectList(db.Miembros, "IdMiembro", "Nombres", zona.IdPastorZona);
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre", zona.IdIglesia);
            ViewBag.IdPastorZona = new SelectList(db.Miembros, "IdMiembro", "Nombres", zona.IdPastorZona);
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZona,Nombre,Descripcion,Direccion,IdPastorZona,IdIglesia")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIglesia = new SelectList(db.Iglesia, "IdIglesia", "Nombre", zona.IdIglesia);
            ViewBag.IdPastorZona = new SelectList(db.Miembros, "IdMiembro", "Nombres", zona.IdPastorZona);
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zona zona = db.Zona.Find(id);
            db.Zona.Remove(zona);
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
