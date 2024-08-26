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
    public class FinancierasController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Financieras
        public ActionResult Index()
        {
            var financieras = db.Financieras.Include(f => f.Usuarios).Include(f => f.Usuarios1);
            return View(financieras.ToList());
        }

        // GET: Financieras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financieras financieras = db.Financieras.Find(id);
            if (financieras == null)
            {
                return HttpNotFound();
            }
            return View(financieras);
        }

        // GET: Financieras/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCreaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Financieras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFinancieraPK,descripcionFinananciera,idUsuarioCreaFinancieraFK,fechaCreaFinanciera,idUsuarioModificaFinancieraFK,fechaModificaFinanciera")] Financieras financieras)
        {
            if (ModelState.IsValid)
            {
                db.Financieras.Add(financieras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCreaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioCreaFinancieraFK);
            ViewBag.idUsuarioModificaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioModificaFinancieraFK);
            return View(financieras);
        }

        // GET: Financieras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financieras financieras = db.Financieras.Find(id);
            if (financieras == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCreaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioCreaFinancieraFK);
            ViewBag.idUsuarioModificaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioModificaFinancieraFK);
            return View(financieras);
        }

        // POST: Financieras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFinancieraPK,descripcionFinananciera,idUsuarioCreaFinancieraFK,fechaCreaFinanciera,idUsuarioModificaFinancieraFK,fechaModificaFinanciera")] Financieras financieras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financieras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCreaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioCreaFinancieraFK);
            ViewBag.idUsuarioModificaFinancieraFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", financieras.idUsuarioModificaFinancieraFK);
            return View(financieras);
        }

        // GET: Financieras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financieras financieras = db.Financieras.Find(id);
            if (financieras == null)
            {
                return HttpNotFound();
            }
            return View(financieras);
        }

        // POST: Financieras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financieras financieras = db.Financieras.Find(id);
            db.Financieras.Remove(financieras);
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
