using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TFSi;

namespace TFSi.Controllers
{
    public class PerfilesController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Perfiles
        public ActionResult Index()
        {
            var perfiles = db.Perfiles.Include(p => p.Usuarios).Include(p => p.Usuarios1);
            return View(perfiles.ToList());
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCreaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Perfiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfilPK,descripcionPerfil,idUsuarioCreaPerfilFK,fechaCreaPerfil,idUsuarioModificaPerfilFK,fechaModificaPerfil")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Perfiles.Add(perfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCreaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioCreaPerfilFK);
            ViewBag.idUsuarioModificaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioModificaPerfilFK);
            return View(perfiles);
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCreaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioCreaPerfilFK);
            ViewBag.idUsuarioModificaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioModificaPerfilFK);
            return View(perfiles);
        }

        // POST: Perfiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfilPK,descripcionPerfil,idUsuarioCreaPerfilFK,fechaCreaPerfil,idUsuarioModificaPerfilFK,fechaModificaPerfil")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCreaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioCreaPerfilFK);
            ViewBag.idUsuarioModificaPerfilFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", perfiles.idUsuarioModificaPerfilFK);
            return View(perfiles);
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            db.Perfiles.Remove(perfiles);
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
