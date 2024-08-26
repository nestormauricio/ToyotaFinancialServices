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
    public class ClasificacionesController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Clasificaciones
        public ActionResult Index()
        {
            var clasificaciones = db.Clasificaciones.Include(c => c.Usuarios).Include(c => c.Usuarios1);
            return View(clasificaciones.ToList());
        }

        // GET: Clasificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            return View(clasificaciones);
        }

        // GET: Clasificaciones/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCreaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Clasificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClasificacionPK,descripcionClasificacion,idUsuarioCreaClasificacionFK,fechaCreaClasificacion,idUsuarioModificaClasificacionFK,fechaModificaClasificacion")] Clasificaciones clasificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Clasificaciones.Add(clasificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCreaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioCreaClasificacionFK);
            ViewBag.idUsuarioModificaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioModificaClasificacionFK);
            return View(clasificaciones);
        }

        // GET: Clasificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCreaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioCreaClasificacionFK);
            ViewBag.idUsuarioModificaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioModificaClasificacionFK);
            return View(clasificaciones);
        }

        // POST: Clasificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClasificacionPK,descripcionClasificacion,idUsuarioCreaClasificacionFK,fechaCreaClasificacion,idUsuarioModificaClasificacionFK,fechaModificaClasificacion")] Clasificaciones clasificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCreaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioCreaClasificacionFK);
            ViewBag.idUsuarioModificaClasificacionFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clasificaciones.idUsuarioModificaClasificacionFK);
            return View(clasificaciones);
        }

        // GET: Clasificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            return View(clasificaciones);
        }

        // POST: Clasificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            db.Clasificaciones.Remove(clasificaciones);
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
