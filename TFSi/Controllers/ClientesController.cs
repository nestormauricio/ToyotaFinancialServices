using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TFSi;

namespace TFSi.Content
{
    public class ClientesController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Clasificaciones).Include(c => c.Usuarios).Include(c => c.Usuarios1);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.idClasificacionClienteFK = new SelectList(db.Clasificaciones, "idClasificacionPK", "descripcionClasificacion");
            ViewBag.idUsuarioCreaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClientePK,descripcionCliente,idClasificacionClienteFK,idUsuarioCreaClienteFK,fechaCreaCliente,idUsuarioModificaClienteFK,fechaModificaCliente")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClasificacionClienteFK = new SelectList(db.Clasificaciones, "idClasificacionPK", "descripcionClasificacion", clientes.idClasificacionClienteFK);
            ViewBag.idUsuarioCreaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioCreaClienteFK);
            ViewBag.idUsuarioModificaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioModificaClienteFK);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClasificacionClienteFK = new SelectList(db.Clasificaciones, "idClasificacionPK", "descripcionClasificacion", clientes.idClasificacionClienteFK);
            ViewBag.idUsuarioCreaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioCreaClienteFK);
            ViewBag.idUsuarioModificaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioModificaClienteFK);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClientePK,descripcionCliente,idClasificacionClienteFK,idUsuarioCreaClienteFK,fechaCreaCliente,idUsuarioModificaClienteFK,fechaModificaCliente")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClasificacionClienteFK = new SelectList(db.Clasificaciones, "idClasificacionPK", "descripcionClasificacion", clientes.idClasificacionClienteFK);
            ViewBag.idUsuarioCreaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioCreaClienteFK);
            ViewBag.idUsuarioModificaClienteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", clientes.idUsuarioModificaClienteFK);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
