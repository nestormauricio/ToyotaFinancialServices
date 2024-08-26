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
    public class PaquetesController : Controller
    {
        private TFSEntities db = new TFSEntities();

        // GET: Paquetes
        public ActionResult Index()
        {
            var paquetes = db.Paquetes.Include(p => p.Financieras).Include(p => p.Usuarios).Include(p => p.Usuarios1).Include(p => p.Vehiculos);
            return View(paquetes.ToList());
        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            return View(paquetes);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            ViewBag.idFinancieraFK = new SelectList(db.Financieras, "idFinancieraPK", "descripcionFinananciera");
            ViewBag.idUsuarioCreaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idUsuarioModificaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario");
            ViewBag.idVehiculoFK = new SelectList(db.Vehiculos, "idVehiculoPK", "descripcionVehiculo");
            return View();
        }

        // POST: Paquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaquetePK,descripcionPaquete,idFinancieraFK,idVehiculoFK,montoSugeridoPaquete,mesesSugeridoPaquete,interesesSugeridoPaquete,cuotaMensualEstimadaPaquete,clausulasPaquete,idUsuarioCreaPaqueteFK,fechaCreaPaquete,idUsuarioModificaPaqueteFK,fechaModificaPaquete")] Paquetes paquetes)
        {
            if (ModelState.IsValid)
            {
                db.Paquetes.Add(paquetes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFinancieraFK = new SelectList(db.Financieras, "idFinancieraPK", "descripcionFinananciera", paquetes.idFinancieraFK);
            ViewBag.idUsuarioCreaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioCreaPaqueteFK);
            ViewBag.idUsuarioModificaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioModificaPaqueteFK);
            ViewBag.idVehiculoFK = new SelectList(db.Vehiculos, "idVehiculoPK", "descripcionVehiculo", paquetes.idVehiculoFK);
            return View(paquetes);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFinancieraFK = new SelectList(db.Financieras, "idFinancieraPK", "descripcionFinananciera", paquetes.idFinancieraFK);
            ViewBag.idUsuarioCreaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioCreaPaqueteFK);
            ViewBag.idUsuarioModificaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioModificaPaqueteFK);
            ViewBag.idVehiculoFK = new SelectList(db.Vehiculos, "idVehiculoPK", "descripcionVehiculo", paquetes.idVehiculoFK);
            return View(paquetes);
        }

        // POST: Paquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaquetePK,descripcionPaquete,idFinancieraFK,idVehiculoFK,montoSugeridoPaquete,mesesSugeridoPaquete,interesesSugeridoPaquete,cuotaMensualEstimadaPaquete,clausulasPaquete,idUsuarioCreaPaqueteFK,fechaCreaPaquete,idUsuarioModificaPaqueteFK,fechaModificaPaquete")] Paquetes paquetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquetes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFinancieraFK = new SelectList(db.Financieras, "idFinancieraPK", "descripcionFinananciera", paquetes.idFinancieraFK);
            ViewBag.idUsuarioCreaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioCreaPaqueteFK);
            ViewBag.idUsuarioModificaPaqueteFK = new SelectList(db.Usuarios, "idUsuarioPK", "descripcionUsuario", paquetes.idUsuarioModificaPaqueteFK);
            ViewBag.idVehiculoFK = new SelectList(db.Vehiculos, "idVehiculoPK", "descripcionVehiculo", paquetes.idVehiculoFK);
            return View(paquetes);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            return View(paquetes);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paquetes paquetes = db.Paquetes.Find(id);
            db.Paquetes.Remove(paquetes);
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
