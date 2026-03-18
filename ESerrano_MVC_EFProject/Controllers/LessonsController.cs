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
    public class LessonsController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Customer).Include(l => l.Ref_Lesson_Status).Include(l => l.Staff).Include(l => l.Vehicle);
            return View(lessons.ToList());
        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name");
            ViewBag.Lesson_Status_code = new SelectList(db.Ref_Lesson_Statuses, "Lesson_Status_Code", "Lesson_Status_Description");
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Vehicle_Details");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,Lesson_Date,Lesson_Time,Price,Other_Lesson_Details,StaffId,CustomerId,VehicleId,Lesson_Status_code")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", lesson.CustomerId);
            ViewBag.Lesson_Status_code = new SelectList(db.Ref_Lesson_Statuses, "Lesson_Status_Code", "Lesson_Status_Description", lesson.Lesson_Status_code);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Vehicle_Details", lesson.VehicleId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", lesson.CustomerId);
            ViewBag.Lesson_Status_code = new SelectList(db.Ref_Lesson_Statuses, "Lesson_Status_Code", "Lesson_Status_Description", lesson.Lesson_Status_code);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Vehicle_Details", lesson.VehicleId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,Lesson_Date,Lesson_Time,Price,Other_Lesson_Details,StaffId,CustomerId,VehicleId,Lesson_Status_code")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", lesson.CustomerId);
            ViewBag.Lesson_Status_code = new SelectList(db.Ref_Lesson_Statuses, "Lesson_Status_Code", "Lesson_Status_Description", lesson.Lesson_Status_code);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Nickname", lesson.StaffId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Vehicle_Details", lesson.VehicleId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
