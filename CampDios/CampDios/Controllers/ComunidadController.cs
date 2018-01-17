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
    public class ComunidadController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Comunidad
        //[Authorize]
        [AuthorizeUserAccesLevel(UserRole = "admin")]
        public ActionResult Index()
        {
            var comunidad = db.Comunidad.Include(c => c.Miembros).Include(c => c.Zona);
            return View(comunidad.ToList());
        }

        // GET: Comunidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidad.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            return View(comunidad);
        }

       public ActionResult GrupoDetalle(int? id)
        {
            var grupo = db.Grupo.Where(g => g.IdComunidad == id);
            return View(grupo);
            
        }

        // GET: Comunidad/Create
        public ActionResult Create()
        {
            /*var result = db.Database.SqlQuery<seleccionar_lider_Result1>("exec seleccionar_lider"); //llamando al procedimiento almacenado "seleccionar_lider"
            ViewBag.IdLiderComunidad = new SelectList(result.ToList(), "IdMiembro", "Nombres"); // pasando lo que viene del Stored Procedure a el dropdown*/
            //ViewBag.IdLiderComunidad = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            var result = db.Database.SqlQuery<seleccionar_lider_Result>("exec seleccionar_lider"); //llamando al procedimiento almacenado "seleccionar_lider"
            ViewBag.IdLiderComunidad = new SelectList(result.ToList(), "IdMiembro","Nombres"); // pasando lo que viene del Stored Procedure a el dropdown
            ViewBag.IdZona = new SelectList(db.Zona, "IdZona", "Nombre");
            return View();
        }

        // POST: Comunidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComunidad,Nombre,Descripcion,Direccion,IdLiderComunidad,IdZona")] Comunidad comunidad)
        {
            if (ModelState.IsValid)
            {
                db.Comunidad.Add(comunidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.IdLiderComunidad = new SelectList(db.Miembros, "IdMiembro", "Nombres", comunidad.IdLiderComunidad);
            ViewBag.IdZona = new SelectList(db.Zona, "IdZona", "Nombre", comunidad.IdZona);
            return View(comunidad);
        }

        // GET: Comunidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidad.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLiderComunidad = new SelectList(db.Miembros, "IdMiembro", "Nombres", comunidad.IdLiderComunidad);
            ViewBag.IdZona = new SelectList(db.Zona, "IdZona", "Nombre", comunidad.IdZona);
            return View(comunidad);
        }

        // POST: Comunidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComunidad,Nombre,Descripcion,Direccion,IdLiderComunidad,IdZona")] Comunidad comunidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comunidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLiderComunidad = new SelectList(db.Miembros, "IdMiembro", "Nombres", comunidad.IdLiderComunidad);
            ViewBag.IdZona = new SelectList(db.Zona, "IdZona", "Nombre", comunidad.IdZona);
            return View(comunidad);
        }

        // GET: Comunidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidad.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            return View(comunidad);
        }

        // POST: Comunidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comunidad comunidad = db.Comunidad.Find(id);
            db.Comunidad.Remove(comunidad);
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
