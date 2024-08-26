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
    public class VentaPaquetesController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: VentaPaquetes
        public ActionResult Index()
        {
            var ventaPaquetes = db.VentaPaquetes.Include(v => v.Clientes).Include(v => v.Paquetes).Include(v => v.Usuarios).Include(v => v.Usuarios1);
            return View(ventaPaquetes.ToList());
        }

        // GET: VentaPaquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquetes ventaPaquetes = db.VentaPaquetes.Find(id);
            if (ventaPaquetes == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquetes);
        }

        // GET: VentaPaquetes/Create
        public ActionResult Create()
        {
            ViewBag.idClienteFK = new SelectList(db.Clientes, "idClientePK", "descripcionCliente");
            ViewBag.idPaqueteFK = new SelectList(db.Paquetes, "idPaquetePK", "descripcionPaquete");
            ViewBag.idUsuarioCreaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: VentaPaquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVentaPaquetePK,numeroVentaPaquete,idClienteFK,idPaqueteFK,idUsuarioCreaVentaPaqueteFK,fechaCreaVentaPaquete,idUsuarioModificaVentaPaqueteFK,fechaModificaVentaPaquete")] VentaPaquetes ventaPaquetes)
        {
            if (ModelState.IsValid)
            {
                db.VentaPaquetes.Add(ventaPaquetes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClienteFK = new SelectList(db.Clientes, "idClientePK", "descripcionCliente", ventaPaquetes.idClienteFK);
            ViewBag.idPaqueteFK = new SelectList(db.Paquetes, "idPaquetePK", "descripcionPaquete", ventaPaquetes.idPaqueteFK);
            ViewBag.idUsuarioCreaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioCreaVentaPaqueteFK);
            ViewBag.idUsuarioModificaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioModificaVentaPaqueteFK);
            return View(ventaPaquetes);
        }

        // GET: VentaPaquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquetes ventaPaquetes = db.VentaPaquetes.Find(id);
            if (ventaPaquetes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClienteFK = new SelectList(db.Clientes, "idClientePK", "descripcionCliente", ventaPaquetes.idClienteFK);
            ViewBag.idPaqueteFK = new SelectList(db.Paquetes, "idPaquetePK", "descripcionPaquete", ventaPaquetes.idPaqueteFK);
            ViewBag.idUsuarioCreaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioCreaVentaPaqueteFK);
            ViewBag.idUsuarioModificaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioModificaVentaPaqueteFK);
            return View(ventaPaquetes);
        }

        // POST: VentaPaquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVentaPaquetePK,numeroVentaPaquete,idClienteFK,idPaqueteFK,idUsuarioCreaVentaPaqueteFK,fechaCreaVentaPaquete,idUsuarioModificaVentaPaqueteFK,fechaModificaVentaPaquete")] VentaPaquetes ventaPaquetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaPaquetes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClienteFK = new SelectList(db.Clientes, "idClientePK", "descripcionCliente", ventaPaquetes.idClienteFK);
            ViewBag.idPaqueteFK = new SelectList(db.Paquetes, "idPaquetePK", "descripcionPaquete", ventaPaquetes.idPaqueteFK);
            ViewBag.idUsuarioCreaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioCreaVentaPaqueteFK);
            ViewBag.idUsuarioModificaVentaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", ventaPaquetes.idUsuarioModificaVentaPaqueteFK);
            return View(ventaPaquetes);
        }

        // GET: VentaPaquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquetes ventaPaquetes = db.VentaPaquetes.Find(id);
            if (ventaPaquetes == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquetes);
        }

        // POST: VentaPaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaPaquetes ventaPaquetes = db.VentaPaquetes.Find(id);
            db.VentaPaquetes.Remove(ventaPaquetes);
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
