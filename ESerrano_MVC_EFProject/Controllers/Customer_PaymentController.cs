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
    public class Customer_PaymentController : Controller
    {
        private DrivingSchoolDbContext db = new DrivingSchoolDbContext();

        // GET: Customer_Payment
        public ActionResult Index()
        {
            var customer_Payments = db.Customer_Payments.Include(c => c.Customer).Include(c => c.Ref_Payment_Methods);
            return View(customer_Payments.ToList());
        }

        // GET: Customer_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            if (customer_Payment == null)
            {
                return HttpNotFound();
            }
            return View(customer_Payment);
        }

        // GET: Customer_Payment/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name");
            ViewBag.Payment_Method_Code = new SelectList(db.Ref_Payment_Methods, "Payment_Method_Code", "Payment_Method_Description");
            return View();
        }

        // POST: Customer_Payment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Datetime_Payment,Ammount_Payment,Other_Payment_Details,Payment_Method_Code")] Customer_Payment customer_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Payments.Add(customer_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", customer_Payment.CustomerId);
            ViewBag.Payment_Method_Code = new SelectList(db.Ref_Payment_Methods, "Payment_Method_Code", "Payment_Method_Description", customer_Payment.Payment_Method_Code);
            return View(customer_Payment);
        }

        // GET: Customer_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            if (customer_Payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", customer_Payment.CustomerId);
            ViewBag.Payment_Method_Code = new SelectList(db.Ref_Payment_Methods, "Payment_Method_Code", "Payment_Method_Description", customer_Payment.Payment_Method_Code);
            return View(customer_Payment);
        }

        // POST: Customer_Payment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Datetime_Payment,Ammount_Payment,Other_Payment_Details,Payment_Method_Code")] Customer_Payment customer_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "First_Name", customer_Payment.CustomerId);
            ViewBag.Payment_Method_Code = new SelectList(db.Ref_Payment_Methods, "Payment_Method_Code", "Payment_Method_Description", customer_Payment.Payment_Method_Code);
            return View(customer_Payment);
        }

        // GET: Customer_Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            if (customer_Payment == null)
            {
                return HttpNotFound();
            }
            return View(customer_Payment);
        }

        // POST: Customer_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            db.Customer_Payments.Remove(customer_Payment);
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
