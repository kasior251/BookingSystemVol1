﻿using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


//endre origin og destination til drop-down lister
namespace BookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFlight(Route route)
        {
            try
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return RedirectToAction("AddFlight");
            }   
        }

        public string GetOrigin()
        {
            List<Route> allRoutes = db.Routes.ToList();

            var allOrigins = new List<string>();

            foreach (Route r in allRoutes)
            {
                string foundOrigin = allOrigins.FirstOrDefault(rl => rl.Contains(r.origin));
                if (foundOrigin == null)
                {
                    // ikke funnet origin i listen, legg den inn i listen
                    allOrigins.Add(r.origin);
                }
            }
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(allOrigins);

        }

        public string GetDestination(string fromOrigin)
        {
            List<Route> allRoutes = db.Routes.ToList();
            var allDestinations = new List<string>();
            foreach (Route r in allRoutes)
            {
                if (r.origin == fromOrigin)
                {
                    string foundDestination = allDestinations.FirstOrDefault(r1 => r1.Contains(r.destination));
                    if (foundDestination == null)
                    {
                        //destination finnes ikke i lista ennå, legges til
                        allDestinations.Add(r.destination);
                    }
                }
            }
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(allDestinations);

        }

        public string GetSchedule(string fromOrigin, string toDestination, int passengers)
        {
            //finn alle routene som tilsvarer valgte strekningen
            List<int> rId = (from r in db.Routes
                             where r.origin == fromOrigin && r.destination == toDestination
                             select r.id).ToList();
            List<Schedule> allFlights = new List<Schedule>();
            foreach (int i in rId)
            {
                allFlights = db.Schedules.Where(s => s.route.id == i && s.seatsLeft >= passengers).ToList();
            }

            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(allFlights);
        }

        public ActionResult BookFlight(int passengers, int flightId)
        {
            Session["Passengers"] = passengers;
            Session["Schedule"] = flightId;
            return View();
        }

        //redirectes ikke hit med til metoden over !#
        [HttpPost]
        public ActionResult BookFLight(List<Passenger> passenger)
        {
            //av en eller annen grunn det er bare én passenger i lista
            var flightId = (int)Session["Schedule"];
            var nr = (int)Session["Passengers"];
            Ticket ticket = new Ticket();
            ticket.schedule = db.Schedules.Find(flightId);
            for (int i = 0; i < passenger.Count; i++)
            {
                db.Passengers.Add(passenger[i]);
            }
            db.Tickets.Add(ticket);
            ticket.passengers = passenger;

            var schedule = (from s in db.Schedules
                         where s.id == flightId
                         select s).FirstOrDefault();
            schedule.seatsLeft -= nr;
                        
            try
            {
                db.SaveChanges();
                Session["Ticket"] = (from t in db.Tickets
                                     where (t.schedule).id == flightId
                                     select t).Last();
                return RedirectToAction("Summary");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Error");
            }
        }

        public ActionResult Summary()
        {
            Ticket ticket = (Ticket)Session["Ticket"];
            return View(ticket);
        }

        public ActionResult Error()
        {
            return View();
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
 