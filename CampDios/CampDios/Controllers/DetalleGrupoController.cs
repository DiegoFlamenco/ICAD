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
    public class DetalleGrupoController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: DetalleGrupo
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "DetalleGrupo")]
        public ActionResult Index()
        {
            var detalleGrupo = db.DetalleGrupo.Include(d => d.Grupo).Include(d => d.Miembros);
            return View(detalleGrupo.ToList());
        }

        // GET: DetalleGrupo/Details/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "DetalleGrupo")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleGrupo detalleGrupo = db.DetalleGrupo.Find(id);
            if (detalleGrupo == null)
            {
                return HttpNotFound();
            }
            return View(detalleGrupo);
        }

        // GET: DetalleGrupo/Create
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "DetalleGrupo")]
        public ActionResult Create()
        {
            ViewBag.IdGrupo = new SelectList(db.Grupo, "IdGrupo", "Nombre");
            //ViewBag.IdMiembro = new SelectList(db.seleccionar_lider_grupo());
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres");
            return View();
        }

        // POST: DetalleGrupo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleGrupo,IdGrupo,IdMiembro")] DetalleGrupo detalleGrupo)
        {
            if (ModelState.IsValid)
            {
                db.DetalleGrupo.Add(detalleGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGrupo = new SelectList(db.Grupo, "IdGrupo", "Nombre", detalleGrupo.IdGrupo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleGrupo.IdMiembro);
            return View(detalleGrupo);
        }

        // GET: DetalleGrupo/Edit/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "DetalleGrupo")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleGrupo detalleGrupo = db.DetalleGrupo.Find(id);
            if (detalleGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGrupo = new SelectList(db.Grupo, "IdGrupo", "Nombre", detalleGrupo.IdGrupo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleGrupo.IdMiembro);
            return View(detalleGrupo);
        }

        // POST: DetalleGrupo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleGrupo,IdGrupo,IdMiembro")] DetalleGrupo detalleGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGrupo = new SelectList(db.Grupo, "IdGrupo", "Nombre", detalleGrupo.IdGrupo);
            ViewBag.IdMiembro = new SelectList(db.Miembros, "IdMiembro", "Nombres", detalleGrupo.IdMiembro);
            return View(detalleGrupo);
        }

        // GET: DetalleGrupo/Delete/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "DetalleGrupo")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleGrupo detalleGrupo = db.DetalleGrupo.Find(id);
            if (detalleGrupo == null)
            {
                return HttpNotFound();
            }
            return View(detalleGrupo);
        }

        // POST: DetalleGrupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleGrupo detalleGrupo = db.DetalleGrupo.Find(id);
            db.DetalleGrupo.Remove(detalleGrupo);
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
