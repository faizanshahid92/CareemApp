using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using URideApp.Models;

namespace URideApp.Controllers
{
    public class CarCompaniesController : Controller
    {
        private FinalMVCProjectQueryEntities db = new FinalMVCProjectQueryEntities();

        // GET: CarCompanies
        public ActionResult Index()
        {
            return View(db.CarCompanies.ToList());
        }

        // GET: CarCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCompany carCompany = db.CarCompanies.Find(id);
            if (carCompany == null)
            {
                return HttpNotFound();
            }
            return View(carCompany);
        }

        // GET: CarCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,CompanyName")] CarCompany carCompany)
        {
            if (ModelState.IsValid)
            {
                db.CarCompanies.Add(carCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carCompany);
        }

        // GET: CarCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCompany carCompany = db.CarCompanies.Find(id);
            if (carCompany == null)
            {
                return HttpNotFound();
            }
            return View(carCompany);
        }

        // POST: CarCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,CompanyName")] CarCompany carCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carCompany);
        }

        // GET: CarCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCompany carCompany = db.CarCompanies.Find(id);
            if (carCompany == null)
            {
                return HttpNotFound();
            }
            return View(carCompany);
        }

        // POST: CarCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarCompany carCompany = db.CarCompanies.Find(id);
            db.CarCompanies.Remove(carCompany);
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
