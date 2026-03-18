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
    public class Ref_Lesson_StatusController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Ref_Lesson_Status
        public ActionResult Index()
        {
            return View(db.Ref_Lesson_Statuses.ToList());
        }

        // GET: Ref_Lesson_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Lesson_Status ref_Lesson_Status = db.Ref_Lesson_Statuses.Find(id);
            if (ref_Lesson_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Lesson_Status);
        }

        // GET: Ref_Lesson_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ref_Lesson_Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lesson_Status_Code,Lesson_Status_Description")] Ref_Lesson_Status ref_Lesson_Status)
        {
            if (ModelState.IsValid)
            {
                db.Ref_Lesson_Statuses.Add(ref_Lesson_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Lesson_Status);
        }

        // GET: Ref_Lesson_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Lesson_Status ref_Lesson_Status = db.Ref_Lesson_Statuses.Find(id);
            if (ref_Lesson_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Lesson_Status);
        }

        // POST: Ref_Lesson_Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lesson_Status_Code,Lesson_Status_Description")] Ref_Lesson_Status ref_Lesson_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Lesson_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Lesson_Status);
        }

        // GET: Ref_Lesson_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Lesson_Status ref_Lesson_Status = db.Ref_Lesson_Statuses.Find(id);
            if (ref_Lesson_Status == null)
            {
                return HttpNotFound();
            }
            return View(ref_Lesson_Status);
        }

        // POST: Ref_Lesson_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_Lesson_Status ref_Lesson_Status = db.Ref_Lesson_Statuses.Find(id);
            db.Ref_Lesson_Statuses.Remove(ref_Lesson_Status);
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
