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
    public class Usuarios_OpcionesController : Controller
    {
        private CampDiosEntities db = new CampDiosEntities();

        // GET: Usuarios_Opciones
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Usuarios_Opciones")]
        public ActionResult Index()
        {
            var usuarios_Opciones = db.Usuarios_Opciones.Include(u => u.Opciones).Include(u => u.Usuarios);
            return View(usuarios_Opciones.ToList());
        }

        // GET: Usuarios_Opciones/Details/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Usuarios_Opciones")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_Opciones usuarios_Opciones = db.Usuarios_Opciones.Find(id);
            if (usuarios_Opciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_Opciones);
        }

        // GET: Usuarios_Opciones/Create
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Usuarios_Opciones")]
        public ActionResult Create()
        {
            ViewBag.Opciones_Opciones_Id = new SelectList(db.Opciones, "Opciones_Id", "Nombre_Opciones");
            ViewBag.Usuarios_Usuario_Id = new SelectList(db.Usuarios, "Usuarios_id", "Login");
            return View();
        }

        // POST: Usuarios_Opciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario_Opciones,Usuarios_Usuario_Id,Opciones_Opciones_Id,Lectura,Escritura,Edicion")] Usuarios_Opciones usuarios_Opciones)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios_Opciones.Add(usuarios_Opciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Opciones_Opciones_Id = new SelectList(db.Opciones, "Opciones_Id", "Nombre_Opciones", usuarios_Opciones.Opciones_Opciones_Id);
            ViewBag.Usuarios_Usuario_Id = new SelectList(db.Usuarios, "Usuarios_id", "Login", usuarios_Opciones.Usuarios_Usuario_Id);
            return View(usuarios_Opciones);
        }

        // GET: Usuarios_Opciones/Edit/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Usuarios_Opciones")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_Opciones usuarios_Opciones = db.Usuarios_Opciones.Find(id);
            if (usuarios_Opciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Opciones_Opciones_Id = new SelectList(db.Opciones, "Opciones_Id", "Nombre_Opciones", usuarios_Opciones.Opciones_Opciones_Id);
            ViewBag.Usuarios_Usuario_Id = new SelectList(db.Usuarios, "Usuarios_id", "Login", usuarios_Opciones.Usuarios_Usuario_Id);
            return View(usuarios_Opciones);
        }

        // POST: Usuarios_Opciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario_Opciones,Usuarios_Usuario_Id,Opciones_Opciones_Id,Lectura,Escritura,Edicion")] Usuarios_Opciones usuarios_Opciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_Opciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Opciones_Opciones_Id = new SelectList(db.Opciones, "Opciones_Id", "Nombre_Opciones", usuarios_Opciones.Opciones_Opciones_Id);
            ViewBag.Usuarios_Usuario_Id = new SelectList(db.Usuarios, "Usuarios_id", "Login", usuarios_Opciones.Usuarios_Usuario_Id);
            return View(usuarios_Opciones);
        }

        // GET: Usuarios_Opciones/Delete/5
        [AuthorizeUserAccesLevel(UserRole = true, Vista = "Usuarios_Opciones")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_Opciones usuarios_Opciones = db.Usuarios_Opciones.Find(id);
            if (usuarios_Opciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_Opciones);
        }

        // POST: Usuarios_Opciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios_Opciones usuarios_Opciones = db.Usuarios_Opciones.Find(id);
            db.Usuarios_Opciones.Remove(usuarios_Opciones);
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
