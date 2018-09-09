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
    [Authorize]

    public class CarInfoesController : Controller
    {
        private FinalMVCProjectQueryEntities db = new FinalMVCProjectQueryEntities();

        // GET: CarInfoes
        public ActionResult Index()
        {
            var carInfoes = db.CarInfoes.Include(c => c.CarCompany).Include(c => c.DriverInfo);
            return View(carInfoes.ToList());
        }

        // GET: CarInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfoes.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            return View(carInfo);
        }

        // GET: CarInfoes/Create
        public ActionResult Create()
        {
            ViewBag.Car_Company = new SelectList(db.CarCompanies, "CompanyId", "CompanyName");
            ViewBag.CarDriver = new SelectList(db.DriverInfoes, "DriverId", "DriverName");
            return View();
        }

        // POST: CarInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Name,Model,Company,RegNo,CarDriver,Car_Company")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                db.CarInfoes.Add(carInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Car_Company = new SelectList(db.CarCompanies, "CompanyId", "CompanyName", carInfo.Car_Company);
            ViewBag.CarDriver = new SelectList(db.DriverInfoes, "DriverId", "DriverName", carInfo.CarDriver);
            return View(carInfo);
        }

        // GET: CarInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfoes.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Car_Company = new SelectList(db.CarCompanies, "CompanyId", "CompanyName", carInfo.Car_Company);
            ViewBag.CarDriver = new SelectList(db.DriverInfoes, "DriverId", "DriverName", carInfo.CarDriver);
            return View(carInfo);
        }

        // POST: CarInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Name,Model,Company,RegNo,CarDriver,Car_Company")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Car_Company = new SelectList(db.CarCompanies, "CompanyId", "CompanyName", carInfo.Car_Company);
            ViewBag.CarDriver = new SelectList(db.DriverInfoes, "DriverId", "DriverName", carInfo.CarDriver);
            return View(carInfo);
        }

        // GET: CarInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfoes.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            return View(carInfo);
        }

        // POST: CarInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarInfo carInfo = db.CarInfoes.Find(id);
            db.CarInfoes.Remove(carInfo);
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
