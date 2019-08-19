using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelJerbourg.Models;

namespace HotelJerbourg.Controllers
{
    public class RoomCategoriesController : Controller
    {
        private HotelJerbourgContext db = new HotelJerbourgContext();

        // GET: RoomCategories
        public ActionResult Index()
        {
            return View(db.RoomCategories.ToList());
        }

        // GET: RoomCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomCategoryID,Category")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                db.RoomCategories.Add(roomCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomCategory);
        }

        // GET: RoomCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomCategoryID,Category")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            db.RoomCategories.Remove(roomCategory);
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
