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
    public class OpcionesController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Opciones
        public ActionResult Index()
        {
            var opciones = db.Opciones.Include(o => o.Modulos);
            return View(opciones.ToList());
        }

        // GET: Opciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opciones opciones = db.Opciones.Find(id);
            if (opciones == null)
            {
                return HttpNotFound();
            }
            return View(opciones);
        }

        // GET: Opciones/Create
        public ActionResult Create()
        {
            ViewBag.Modulos_Modulos_Id = new SelectList(db.Modulos, "Modulos_Id", "Nombre_Modulos");
            return View();
        }

        // POST: Opciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Opciones_Id,Nombre_Opciones,Modulos_Modulos_Id")] Opciones opciones)
        {
            if (ModelState.IsValid)
            {
                db.Opciones.Add(opciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Modulos_Modulos_Id = new SelectList(db.Modulos, "Modulos_Id", "Nombre_Modulos", opciones.Modulos_Modulos_Id);
            return View(opciones);
        }

        // GET: Opciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opciones opciones = db.Opciones.Find(id);
            if (opciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Modulos_Modulos_Id = new SelectList(db.Modulos, "Modulos_Id", "Nombre_Modulos", opciones.Modulos_Modulos_Id);
            return View(opciones);
        }

        // POST: Opciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Opciones_Id,Nombre_Opciones,Modulos_Modulos_Id")] Opciones opciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Modulos_Modulos_Id = new SelectList(db.Modulos, "Modulos_Id", "Nombre_Modulos", opciones.Modulos_Modulos_Id);
            return View(opciones);
        }

        // GET: Opciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opciones opciones = db.Opciones.Find(id);
            if (opciones == null)
            {
                return HttpNotFound();
            }
            return View(opciones);
        }

        // POST: Opciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opciones opciones = db.Opciones.Find(id);
            db.Opciones.Remove(opciones);
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
