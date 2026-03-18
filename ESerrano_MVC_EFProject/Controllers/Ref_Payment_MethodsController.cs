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
    public class Ref_Payment_MethodsController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Ref_Payment_Methods
        public ActionResult Index()
        {
            return View(db.Ref_Payment_Methods.ToList());
        }

        // GET: Ref_Payment_Methods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Methods ref_Payment_Methods = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Methods == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Methods);
        }

        // GET: Ref_Payment_Methods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ref_Payment_Methods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Payment_Method_Code,Payment_Method_Description")] Ref_Payment_Methods ref_Payment_Methods)
        {
            if (ModelState.IsValid)
            {
                db.Ref_Payment_Methods.Add(ref_Payment_Methods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Payment_Methods);
        }

        // GET: Ref_Payment_Methods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Methods ref_Payment_Methods = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Methods == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Methods);
        }

        // POST: Ref_Payment_Methods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Payment_Method_Code,Payment_Method_Description")] Ref_Payment_Methods ref_Payment_Methods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Payment_Methods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Payment_Methods);
        }

        // GET: Ref_Payment_Methods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Payment_Methods ref_Payment_Methods = db.Ref_Payment_Methods.Find(id);
            if (ref_Payment_Methods == null)
            {
                return HttpNotFound();
            }
            return View(ref_Payment_Methods);
        }

        // POST: Ref_Payment_Methods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_Payment_Methods ref_Payment_Methods = db.Ref_Payment_Methods.Find(id);
            db.Ref_Payment_Methods.Remove(ref_Payment_Methods);
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
