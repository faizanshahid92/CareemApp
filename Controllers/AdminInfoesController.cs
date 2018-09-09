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
    public class AdminInfoesController : Controller
    {
        private FinalMVCProjectQueryEntities db = new FinalMVCProjectQueryEntities();

        // GET: AdminInfoes
        public ActionResult Index()
        {
            return View(db.AdminInfoes.ToList());
        }

        // GET: AdminInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminInfo adminInfo = db.AdminInfoes.Find(id);
            if (adminInfo == null)
            {
                return HttpNotFound();
            }
            return View(adminInfo);
        }

        // GET: AdminInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,Name,HireDate,Gender,PhoneNo,HomeAddress,Email")] AdminInfo adminInfo)
        {
            if (ModelState.IsValid)
            {
                db.AdminInfoes.Add(adminInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminInfo);
        }

        // GET: AdminInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminInfo adminInfo = db.AdminInfoes.Find(id);
            if (adminInfo == null)
            {
                return HttpNotFound();
            }
            return View(adminInfo);
        }

        // POST: AdminInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,Name,HireDate,Gender,PhoneNo,HomeAddress,Email")] AdminInfo adminInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminInfo);
        }

        // GET: AdminInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminInfo adminInfo = db.AdminInfoes.Find(id);
            if (adminInfo == null)
            {
                return HttpNotFound();
            }
            return View(adminInfo);
        }

        // POST: AdminInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminInfo adminInfo = db.AdminInfoes.Find(id);
            db.AdminInfoes.Remove(adminInfo);
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
