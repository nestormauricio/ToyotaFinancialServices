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
    public class ConveniosController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Convenios
        public ActionResult Index()
        {
            return View(db.Convenios.ToList());
        }

        // GET: Convenios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenios convenios = db.Convenios.Find(id);
            if (convenios == null)
            {
                return HttpNotFound();
            }
            return View(convenios);
        }

        // GET: Convenios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convenios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConvenioPK,descripcionConvenio,idUsuarioCreaConvenioFK,fechaCreaConvenio,idUsuarioModificaConvenioFK,fechaModificaConvenio")] Convenios convenios)
        {
            if (ModelState.IsValid)
            {
                db.Convenios.Add(convenios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(convenios);
        }

        // GET: Convenios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenios convenios = db.Convenios.Find(id);
            if (convenios == null)
            {
                return HttpNotFound();
            }
            return View(convenios);
        }

        // POST: Convenios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConvenioPK,descripcionConvenio,idUsuarioCreaConvenioFK,fechaCreaConvenio,idUsuarioModificaConvenioFK,fechaModificaConvenio")] Convenios convenios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convenios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(convenios);
        }

        // GET: Convenios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenios convenios = db.Convenios.Find(id);
            if (convenios == null)
            {
                return HttpNotFound();
            }
            return View(convenios);
        }

        // POST: Convenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Convenios convenios = db.Convenios.Find(id);
            db.Convenios.Remove(convenios);
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
