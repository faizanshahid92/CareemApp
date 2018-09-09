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

    public class DriverInfoesController : Controller
    {
        private FinalMVCProjectQueryEntities db = new FinalMVCProjectQueryEntities();

        // GET: DriverInfoes
        public ActionResult Index()
        {
            return View(db.DriverInfoes.ToList());
        }
     
        // GET: DriverInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverInfo driverInfo = db.DriverInfoes.Find(id);
            if (driverInfo == null)
            {
                return HttpNotFound();
            }
            return View(driverInfo);
        }

        // GET: DriverInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,DriverName,DriverHireDate,BirthDate,Gender,HomeAddress,Email,PhoneNo,LicenseNo")] DriverInfo driverInfo)
        {
            if (ModelState.IsValid)
            {
                db.DriverInfoes.Add(driverInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverInfo);
        }

        // GET: DriverInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverInfo driverInfo = db.DriverInfoes.Find(id);
            if (driverInfo == null)
            {
                return HttpNotFound();
            }
            return View(driverInfo);
        }

        // POST: DriverInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,DriverName,DriverHireDate,BirthDate,Gender,HomeAddress,Email,PhoneNo,LicenseNo")] DriverInfo driverInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverInfo);
        }

        // GET: DriverInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverInfo driverInfo = db.DriverInfoes.Find(id);
            if (driverInfo == null)
            {
                return HttpNotFound();
            }
            return View(driverInfo);
        }

        // POST: DriverInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverInfo driverInfo = db.DriverInfoes.Find(id);
            db.DriverInfoes.Remove(driverInfo);
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
