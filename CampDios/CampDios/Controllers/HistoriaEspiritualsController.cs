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
    public class HistoriaEspiritualsController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: HistoriaEspirituals
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Miembros", Permiso = "Lectura")]
        public ActionResult Index()
        {
            var historiaEspiritual = db.HistoriaEspiritual.Include(h => h.Iglesia).Include(h => h.Miembros);
            return View(historiaEspiritual.ToList());
        }

        // GET: HistoriaEspirituals/Details/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Miembros", Permiso = "Lectura")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaEspiritual historiaEspiritual = db.HistoriaEspiritual.Find(id);
            if (historiaEspiritual == null)
            {
                return HttpNotFound();
            }
            return View(historiaEspiritual);
        }

        // GET: HistoriaEspirituals/Create
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Miembros", Permiso = "Escritura")]
        public ActionResult Create()
        {
            ViewBag.IglesiaBautismo = new SelectList(db.Iglesia, "IdIglesia", "Nombre");
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            return View();
        }

        // POST: HistoriaEspirituals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHistoria,IdMiembro,FechaConversion,FechaBautismo,IglesiaBautismo")] HistoriaEspiritual historiaEspiritual)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaEspiritual.Add(historiaEspiritual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IglesiaBautismo = new SelectList(db.Iglesia, "IdIglesia", "Nombre", historiaEspiritual.IglesiaBautismo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", historiaEspiritual.IdMiembro);
            return View(historiaEspiritual);
        }

        // GET: HistoriaEspirituals/Edit/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Miembros", Permiso = "Edicion")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaEspiritual historiaEspiritual = db.HistoriaEspiritual.Find(id);
            if (historiaEspiritual == null)
            {
                return HttpNotFound();
            }
            ViewBag.IglesiaBautismo = new SelectList(db.Iglesia, "IdIglesia", "Nombre", historiaEspiritual.IglesiaBautismo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", historiaEspiritual.IdMiembro);
            return View(historiaEspiritual);
        }

        // POST: HistoriaEspirituals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHistoria,IdMiembro,FechaConversion,FechaBautismo,IglesiaBautismo")] HistoriaEspiritual historiaEspiritual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaEspiritual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IglesiaBautismo = new SelectList(db.Iglesia, "IdIglesia", "Nombre", historiaEspiritual.IglesiaBautismo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", historiaEspiritual.IdMiembro);
            return View(historiaEspiritual);
        }

        // GET: HistoriaEspirituals/Delete/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Miembros", Permiso = "Edicion")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaEspiritual historiaEspiritual = db.HistoriaEspiritual.Find(id);
            if (historiaEspiritual == null)
            {
                return HttpNotFound();
            }
            return View(historiaEspiritual);
        }

        // POST: HistoriaEspirituals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoriaEspiritual historiaEspiritual = db.HistoriaEspiritual.Find(id);
            db.HistoriaEspiritual.Remove(historiaEspiritual);
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
