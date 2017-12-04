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
    public class GrupoController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Grupo
        public ActionResult Index()
        {
            var grupo = db.Grupo.Include(g => g.Comunidad).Include(g => g.Dias).Include(g => g.Tipo_Grupo);
            return View(grupo.ToList());
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            ViewBag.IdComunidad = new SelectList(db.Comunidad, "IdComunidad", "Nombre");
            ViewBag.IdDia = new SelectList(db.Dias, "IdDia", "Dia");
            ViewBag.IdTipoGrupo = new SelectList(db.Tipo_Grupo, "IdTipoGrupo", "Descripcion");
            return View();
        }

        // POST: Grupo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupo,Nombre,Descripcion,Direccion,IdComunidad,IdDia,Hora,IdTipoGrupo")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupo.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdComunidad = new SelectList(db.Comunidad, "IdComunidad", "Nombre", grupo.IdComunidad);
            ViewBag.IdDia = new SelectList(db.Dias, "IdDia", "Dia", grupo.IdDia);
            ViewBag.IdTipoGrupo = new SelectList(db.Tipo_Grupo, "IdTipoGrupo", "Descripcion", grupo.IdTipoGrupo);
            return View(grupo);
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdComunidad = new SelectList(db.Comunidad, "IdComunidad", "Nombre", grupo.IdComunidad);
            ViewBag.IdDia = new SelectList(db.Dias, "IdDia", "Dia", grupo.IdDia);
            ViewBag.IdTipoGrupo = new SelectList(db.Tipo_Grupo, "IdTipoGrupo", "Descripcion", grupo.IdTipoGrupo);
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupo,Nombre,Descripcion,Direccion,IdComunidad,IdDia,Hora,IdTipoGrupo")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdComunidad = new SelectList(db.Comunidad, "IdComunidad", "Nombre", grupo.IdComunidad);
            ViewBag.IdDia = new SelectList(db.Dias, "IdDia", "Dia", grupo.IdDia);
            ViewBag.IdTipoGrupo = new SelectList(db.Tipo_Grupo, "IdTipoGrupo", "Descripcion", grupo.IdTipoGrupo);
            return View(grupo);
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupo.Find(id);
            db.Grupo.Remove(grupo);
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
