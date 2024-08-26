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
    public class UsuariosController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Perfiles2).Include(u => u.Usuarios2).Include(u => u.Usuarios3);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idPerfilUsuarioFK = new SelectList(db.Perfiles, "idPerfilPK", "descripcionPerfil");
            ViewBag.idUsuarioCreaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuarioPK,descripcionUsuario,idUsuarioCreaUsuarioFK,fechaCreaUsuario,idUsuarioModificaUsuarioFK,fechaModificaUsuario,idPerfilUsuarioFK")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPerfilUsuarioFK = new SelectList(db.Perfiles, "idPerfilPK", "descripcionPerfil", usuarios.idPerfilUsuarioFK);
            ViewBag.idUsuarioCreaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioCreaUsuarioFK);
            ViewBag.idUsuarioModificaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioModificaUsuarioFK);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPerfilUsuarioFK = new SelectList(db.Perfiles, "idPerfilPK", "descripcionPerfil", usuarios.idPerfilUsuarioFK);
            ViewBag.idUsuarioCreaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioCreaUsuarioFK);
            ViewBag.idUsuarioModificaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioModificaUsuarioFK);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuarioPK,descripcionUsuario,idUsuarioCreaUsuarioFK,fechaCreaUsuario,idUsuarioModificaUsuarioFK,fechaModificaUsuario,idPerfilUsuarioFK")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPerfilUsuarioFK = new SelectList(db.Perfiles, "idPerfilPK", "descripcionPerfil", usuarios.idPerfilUsuarioFK);
            ViewBag.idUsuarioCreaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioCreaUsuarioFK);
            ViewBag.idUsuarioModificaUsuarioFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", usuarios.idUsuarioModificaUsuarioFK);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
