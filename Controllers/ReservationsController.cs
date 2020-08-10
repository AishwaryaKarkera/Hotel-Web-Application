using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wanderlust04.Models;

namespace Wanderlust04.Controllers
{
    public class ReservationsController : Controller
    {
        private Wanderlust_Models db = new Wanderlust_Models();

        // GET: Reservations
        [Authorize]
        public ActionResult Index()
        {
            Reservation reservation = db.Reservation.Find(db.Reservation.Max(model => model.Id));
            reservation.RoomId = db.Rooms.Max(model => model.Id);
            reservation.GuestId = User.Identity.GetUserId();
            return View(db.Reservation.ToList());
            
        }

        // GET: Reservations/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            reservation.RoomId = db.Rooms.Max(model => model.Id);
            db.Reservation.Add(reservation);
            db.SaveChanges();
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            return View(reservation);
        }


        public ActionResult rating(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Table == null)
            {
                return View(new List<Rating>());
            }
            var ratingsP = db.Table.Where(model => (model.ReservationId == id));
            List<Rating> ratings = new List<Rating>();
            if (ratingsP != null)
            {
                ratings = db.Table.Where(model => (model.ReservationId == id)).ToList();
            }
            return View(ratings);
        } 

        public ActionResult CreateRating()
        {
            return View();
        }
        public ActionResult CreateRating1([Bind(Include = "Comment,rating,ReservationId")] Rating rating)
        {
            if (db.Table == null) {
                return RedirectToAction("Index");
            }
            rating.Id = db.Table.Max(model => model.Id) + 1;
            if (ModelState.IsValid)
            {
                db.Table.Add(rating);
                db.SaveChanges();
            }
            return RedirectToAction("rating");
        }

        // GET: Reservations/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "CheckIn,CheckOut,RoomId,GuestId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Id = db.Reservation.Count();
                reservation.RoomId = 0;
                Guest guest = null;
                if (db.Guests.Find(User.Identity.GetUserId()) == null)
                {
                    guest = new Guest();
                    guest.Id = User.Identity.GetUserId();
                    db.Guests.Add(guest);
                }
                else {
                    guest = db.Guests.Find(User.Identity.GetUserId());
                }
                reservation.GuestId = guest.Id;
                try
                {
                    db.Reservation.Add(reservation);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }

            return RedirectToAction("Index","Hotels");

        }



        // GET: Reservations/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
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
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,CheckIn,CheckOut,RoomId,GuestId")] Reservation reservation)
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
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservation.Find(id);
            db.Reservation.Remove(reservation);
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
