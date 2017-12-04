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
    public class DetalleFamiliasController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: DetalleFamilias
        public ActionResult Index()
        {
            var detalleFamilia = db.DetalleFamilia.Include(d => d.Miembros).Include(d => d.Miembros1).Include(d => d.Parentescos);
            return View(detalleFamilia.ToList());
        }

        // GET: DetalleFamilias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFamilia detalleFamilia = db.DetalleFamilia.Find(id);
            if (detalleFamilia == null)
            {
                return HttpNotFound();
            }
            return View(detalleFamilia);
        }

        // GET: DetalleFamilias/Create
        public ActionResult Create()
        {
           
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            ViewBag.IdPariente = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            ViewBag.IdParentesco = new SelectList(db.Parentescos, "IdParentesco", "Parentesco");
            return View();

            
        }
        

        // POST: DetalleFamilias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "IdDetalleFamilia,IdMiembro,IdPariente,IdParentesco")] DetalleFamilia detalleFamilia)
        {
            if(detalleFamilia.IdMiembro != detalleFamilia.IdPariente) { 
            if (ModelState.IsValid)
            {
                db.DetalleFamilia.Add(detalleFamilia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdMiembro);
            ViewBag.IdPariente = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdPariente);
            ViewBag.IdParentesco = new SelectList(db.Parentescos, "IdParentesco", "Parentesco", detalleFamilia.IdParentesco);
            }else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No se puede asociar parentesco a una misma persona')</script>");
                ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdMiembro);
                ViewBag.IdPariente = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdPariente);
                ViewBag.IdParentesco = new SelectList(db.Parentescos, "IdParentesco", "Parentesco", detalleFamilia.IdParentesco);
            }

            return View(detalleFamilia);
        }

        // GET: DetalleFamilias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFamilia detalleFamilia = db.DetalleFamilia.Find(id);
            if (detalleFamilia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdMiembro);
            ViewBag.IdPariente = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdPariente);
            ViewBag.IdParentesco = new SelectList(db.Parentescos, "IdParentesco", "Parentesco", detalleFamilia.IdParentesco);
            return View(detalleFamilia);
        }

        // POST: DetalleFamilias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleFamilia,IdMiembro,IdPariente,IdParentesco")] DetalleFamilia detalleFamilia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFamilia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdMiembro);
            ViewBag.IdPariente = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleFamilia.IdPariente);
            ViewBag.IdParentesco = new SelectList(db.Parentescos, "IdParentesco", "Parentesco", detalleFamilia.IdParentesco);
            return View(detalleFamilia);

        }

        // GET: DetalleFamilias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFamilia detalleFamilia = db.DetalleFamilia.Find(id);
            if (detalleFamilia == null)
            {
                return HttpNotFound();
            }
            return View(detalleFamilia);
        }

        // POST: DetalleFamilias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFamilia detalleFamilia = db.DetalleFamilia.Find(id);
            db.DetalleFamilia.Remove(detalleFamilia);
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
