using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerDBEntities db = new FortuneTellerDBEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            int age;
            if (customer.Age % 2 == 0)
            {
                age = 20;
            }
            else
            {
                age = 15;
            }
            ViewBag.RetirementAge = age;

            int birthMonth;
            if (customer.BirthMonth == "January" || customer.BirthMonth =="February" || customer.BirthMonth == "March" || customer.BirthMonth == "April" )
            {
                birthMonth = 20000;
            }
            else if (customer.BirthMonth == "May" || customer.BirthMonth == "June" || customer.BirthMonth == "July" || customer.BirthMonth == "August")
            {
                birthMonth = 25000;
            }
            else if (customer.BirthMonth == "September" || customer.BirthMonth == "October" || customer.BirthMonth == "November" || customer.BirthMonth == "December")
            {
                birthMonth = 30000;
            }
            else
            {
                birthMonth = 0;
            }
            ViewBag.BirthMonth = birthMonth;

            string favoriteColor;
            switch (customer.FavoriteColor.ToLower())
            {
                case "red":
                    favoriteColor = "plane";
                    break;
                case "orange":
                    favoriteColor = "Flying Nimbus";
                    break;
                case "yellow":
                    favoriteColor = "Honda Element";
                    break;
                case "green":
                    favoriteColor = "Delorean";
                    break;
                case "blue":
                    favoriteColor = "Koenigsegg Agera R";
                    break;
                case "indigo":
                    favoriteColor = "Porsche 911";
                    break;
                case "violet":
                    favoriteColor = "pogo stick";
                    break;
                default:
                    favoriteColor = "motorized scooter";
                    break;
            }
            ViewBag.FavoriteColor = favoriteColor;

            string vacationHome;
            if (customer.NumberOfSiblings == 0)
            {
                vacationHome = "Miami";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                vacationHome = "Paris";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                vacationHome = "San Fransisco";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                vacationHome = "Rome";
            }
            else if (customer.NumberOfSiblings > 3)
            {
                vacationHome = "Cancun";
            }
            else
            {
                vacationHome = "Detroit";
            }
            ViewBag.NumberOfSiblings = vacationHome;
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,NumberOfSiblings,FavoriteColor")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,NumberOfSiblings,FavoriteColor")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
