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
    public class VehiculosController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Vehiculos
        public ActionResult Index()
        {
            var vehiculos = db.Vehiculos.Include(v => v.Convenios).Include(v => v.Usuarios).Include(v => v.Usuarios1);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculos vehiculos = db.Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.idConvenioFK = new SelectList(db.Convenios, "idConvenioPK", "descripcionConvenio");
            ViewBag.idUsuarioCreaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            return View();
        }

        // POST: Vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVehiculoPK,descripcionVehiculo,matriculaVehiculo,idConvenioFK,idUsuarioCreaVehiculoFK,fechaCreaVehiculo,idUsuarioModificaVehiculoFK,fechaModificaVehiculo")] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculos.Add(vehiculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConvenioFK = new SelectList(db.Convenios, "idConvenioPK", "descripcionConvenio", vehiculos.idConvenioFK);
            ViewBag.idUsuarioCreaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioCreaVehiculoFK);
            ViewBag.idUsuarioModificaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioModificaVehiculoFK);
            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculos vehiculos = db.Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConvenioFK = new SelectList(db.Convenios, "idConvenioPK", "descripcionConvenio", vehiculos.idConvenioFK);
            ViewBag.idUsuarioCreaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioCreaVehiculoFK);
            ViewBag.idUsuarioModificaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioModificaVehiculoFK);
            return View(vehiculos);
        }

        // POST: Vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVehiculoPK,descripcionVehiculo,matriculaVehiculo,idConvenioFK,idUsuarioCreaVehiculoFK,fechaCreaVehiculo,idUsuarioModificaVehiculoFK,fechaModificaVehiculo")] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConvenioFK = new SelectList(db.Convenios, "idConvenioPK", "descripcionConvenio", vehiculos.idConvenioFK);
            ViewBag.idUsuarioCreaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioCreaVehiculoFK);
            ViewBag.idUsuarioModificaVehiculoFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", vehiculos.idUsuarioModificaVehiculoFK);
            return View(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculos vehiculos = db.Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculos vehiculos = db.Vehiculos.Find(id);
            db.Vehiculos.Remove(vehiculos);
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
