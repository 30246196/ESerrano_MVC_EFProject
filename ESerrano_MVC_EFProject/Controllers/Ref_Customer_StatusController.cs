using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESerrano_MVC_EFProject.Models;

namespace ESerrano_MVC_EFProject.Controllers
{
    public class Ref_Customer_StatusController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Ref_Customer_Status
        public ActionResult Index()
        {
            return View(db.Ref_Customer_Statuses.ToList());
        }

        // GET: Ref_Customer_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Customer_Status ref_Customer_Status = db.Ref_Customer_Statuses.Find(id);
            if (ref_Customer_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Customer_Status);
        }

        // GET: Ref_Customer_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ref_Customer_Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_Status_Code,Customer_Status_Description")] Ref_Customer_Status ref_Customer_Status)
        {
            if (ModelState.IsValid)
            {
                db.Ref_Customer_Statuses.Add(ref_Customer_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Customer_Status);
        }

        // GET: Ref_Customer_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Customer_Status ref_Customer_Status = db.Ref_Customer_Statuses.Find(id);
            if (ref_Customer_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Customer_Status);
        }

        // POST: Ref_Customer_Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_Status_Code,Customer_Status_Description")] Ref_Customer_Status ref_Customer_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Customer_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Customer_Status);
        }

        // GET: Ref_Customer_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Customer_Status ref_Customer_Status = db.Ref_Customer_Statuses.Find(id);
            if (ref_Customer_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Customer_Status);
        }

        // POST: Ref_Customer_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_Customer_Status ref_Customer_Status = db.Ref_Customer_Statuses.Find(id);
            db.Ref_Customer_Statuses.Remove(ref_Customer_Status);
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
