﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelJerbourg.Models;
using HotelJerbourg.DAL;

namespace HotelJerbourg.Controllers
{
    public class ReservationsController : Controller
    {
        private HotelContext db = new HotelContext();
        private ModelsVM viewModel = new ModelsVM();

        // GET: Reservations
        public ActionResult Index()
        {
            return View(db.Reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            List<SelectListItem> roomItems = new List<SelectListItem>();
            foreach (var r in db.Rooms.ToList())
            {
                SelectListItem li = new SelectListItem
                {
                    Value = r.RoomID.ToString(),
                    Text = r.Number.ToString(),
                };
                roomItems.Add(li);
            }
            ViewBag.Rooms = roomItems;


            List<SelectListItem> clientItems = new List<SelectListItem>();
            foreach (var r in db.Clients.ToList())
            {
                SelectListItem li = new SelectListItem
                {
                    Value = r.ClientID.ToString(),
                    Text = r.LastName.ToString(),
                };
                clientItems.Add(li);
            }
            ViewBag.Clients = clientItems;

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,RoomFK,ClientFK,Date")] Reservation reservation, FormCollection form)
        {
            //string roomID = Request.Form["Rooms"];
            int roomID = Int32.Parse(Request.Form["Rooms"]);
            //string clientID = Request.Form["Clients"];
            int clientID = Int32.Parse(Request.Form["Clients"]);
            //string date = Request.Form["Date"];
            DateTime date = DateTime.Parse(Request.Form["Date"]);

            if (ModelState.IsValid)
            {
                reservation.Room = db.Rooms.Find(roomID);
                reservation.RoomFK = roomID;
                reservation.Client = db.Clients.Find(clientID);
                reservation.ClientFK = clientID;

                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,RoomFK,ClientFK")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
