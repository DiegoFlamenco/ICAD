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
    public class IglesiasController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Iglesias
        public ActionResult Index()
        {
            var iglesia = db.Iglesia.Include(i => i.Miembros);
            return View(iglesia.ToList());
        }

        // GET: Iglesias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesia.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            return View(iglesia);
        }

        public ActionResult ZonaDetalle(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Where(z => z.IdIglesia == id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);*/
 
            var zona = db.Zona.Where(z => z.IdIglesia == id);
            return View(zona);

        }

        // GET: Iglesias/Create
        public ActionResult Create()
        {
            var result = db.Database.SqlQuery<seleccionar_pastor_iglesia_Result>("exec seleccionar_pastor_iglesia");
            ViewBag.IdMiembro = new SelectList(result.ToList(), "IdMiembro", "Nombres");
            //ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            return View();
        }

        // POST: Iglesias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIglesia,Nombre,Direccion,Tel,Tel2,Tel3,Email,IdMiembro")] Iglesia iglesia)
        {
            if (ModelState.IsValid)
            {
                db.Iglesia.Add(iglesia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", iglesia.IdMiembro);
            return View(iglesia);
        }

        // GET: Iglesias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesia.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", iglesia.IdMiembro);
            return View(iglesia);
        }

        // POST: Iglesias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIglesia,Nombre,Direccion,Tel,Tel2,Tel3,Email,IdMiembro")] Iglesia iglesia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iglesia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", iglesia.IdMiembro);
            return View(iglesia);
        }

        // GET: Iglesias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesia.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            return View(iglesia);
        }

        // POST: Iglesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iglesia iglesia = db.Iglesia.Find(id);
            db.Iglesia.Remove(iglesia);
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
