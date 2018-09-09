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

    public class PassengerInfoesController : Controller
    {
        private FinalMVCProjectQueryEntities db = new FinalMVCProjectQueryEntities();

        // GET: PassengerInfoes
        public ActionResult Index()
        {
            return View(db.PassengerInfoes.ToList());
        }

        // GET: PassengerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassengerId,PassengerName,Gender,CellNo,PermenantAddress")] PassengerInfo passengerInfo)
        {
            if (ModelState.IsValid)
            {
                db.PassengerInfoes.Add(passengerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PassengerId,PassengerName,Gender,CellNo,PermenantAddress")] PassengerInfo passengerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passengerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            db.PassengerInfoes.Remove(passengerInfo);
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
