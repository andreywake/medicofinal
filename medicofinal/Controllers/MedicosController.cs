using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medicofinal.DAO;
using medicofinal.Models;

namespace medicofinal.Controllers
{
    public class MedicosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Cidade).Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome");
            return View();
        }

        // POST: Medicos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicoID,EspecialidadeID,CidadeID,CRM,Nome,Endereco,Email,Convenio,pClinica")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,EspecialidadeID,CidadeID,CRM,Nome,Endereco,Email,Convenio,pClinica")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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
