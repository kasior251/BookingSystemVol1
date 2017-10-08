using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var routes = new List<Route>()
            {
                new Route { origin = "Oslo", destination = "Mancheser"},
                new Route { origin = "Manchester", destination = "Oslo"},
                new Route { origin = "Oslo", destination = "Berlin"},
                new Route { origin = "Berlin", destination = "Oslo"},
                new Route { origin = "Oslo", destination = "Bergen"},
                new Route { origin = "Bergen", destination = "Oslo"},
                new Route { origin = "Bergen", destination = "Berlin"},
                new Route { origin = "Berlin", destination = "Bergen"},
                new Route { origin = "Bergen", destination = "Brussels"},
                new Route { origin = "Brussels", destination = "Bergen"},
                new Route { origin = "Bergen", destination = "Alta"},
                new Route { origin = "Alta", destination = "Bergen"},
                new Route { origin = "Bergen", destination = "Munchen"},
                new Route { origin = "Munchen", destination = "Bergen"},
                new Route { origin = "Bergen", destination = "Warszawa"},
                new Route { origin = "Warszawa", destination = "Bergen"}
            };
            //før routes legges inn i tabellen må det tas til schedule
            var schedules = new List<Schedule>()
            {
                //Oslo - Manchester
                new Schedule { route = routes[0], departureDate = "01-11-2017 08:00",
                    arrivalDate = "01-11-2017 11:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[1], departureDate = "01-11-2017 12:00",
                    arrivalDate = "01-11-2017 15:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[0], departureDate = "03-11-2017 08:00",
                    arrivalDate = "03-11-2017 11:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[1], departureDate = "03-11-2017 12:00",
                    arrivalDate = "03-11-2017 15:00", seatsLeft = 100, price = 1099 },
                //Oslo - Berlin
                new Schedule { route = routes[2], departureDate = "01-11-2017 09:00",
                    arrivalDate = "01-11-2017 12:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[3], departureDate = "01-11-2017 13:00",
                    arrivalDate = "01-11-2017 16:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[2], departureDate = "03-11-2017 09:00",
                    arrivalDate = "013-11-2017 12:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[3], departureDate = "03-11-2017 13:00",
                    arrivalDate = "03-11-2017 16:00", seatsLeft = 100, price = 1099 },
                //Oslo - Bergen
                new Schedule { route = routes[4], departureDate = "01-11-2017 10:00",
                    arrivalDate = "01-11-2017 11:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[5], departureDate = "01-11-2017 20:30",
                    arrivalDate = "01-11-2017 22:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[4], departureDate = "03-11-2017 10:00",
                    arrivalDate = "03-11-2017 11:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[5], departureDate = "03-11-2017 20:30",
                    arrivalDate = "03-11-2017 22:00", seatsLeft = 100, price = 1099 },
                //Bergen - Berlin
                new Schedule { route = routes[6], departureDate = "01-11-2017 12:30",
                    arrivalDate = "01-11-2017 15:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[7], departureDate = "01-11-2017 16:30",
                    arrivalDate = "01-11-2017 19:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[6], departureDate = "03-11-2017 12:30",
                    arrivalDate = "03-11-2017 15:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[7], departureDate = "03-11-2017 16:30",
                    arrivalDate = "03-11-2017 19:30", seatsLeft = 100, price = 1099 },
                //Bergen - Brussels
                new Schedule { route = routes[8], departureDate = "01-11-2017 08:00",
                    arrivalDate = "01-11-2017 12:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[9], departureDate = "01-11-2017 13:00",
                    arrivalDate = "01-11-2017 17:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[8], departureDate = "03-11-2017 08:00",
                    arrivalDate = "03-11-2017 12:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[9], departureDate = "03-11-2017 13:00",
                    arrivalDate = "03-11-2017 17:00", seatsLeft = 100, price = 1099 },
                //Bergen - Alta
                new Schedule { route = routes[10], departureDate = "02-11-2017 08:00",
                    arrivalDate = "02-11-2017 09:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[11], departureDate = "02-11-2017 10:30",
                    arrivalDate = "02-11-2017 12:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[10], departureDate = "04-11-2017 08:00",
                    arrivalDate = "04-11-2017 09:30", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[11], departureDate = "04-11-2017 10:30",
                    arrivalDate = "04-11-2017 12:00", seatsLeft = 100, price = 1099 },
                //Bergen - Munchen
                new Schedule { route = routes[12], departureDate = "02-11-2017 13:00",
                    arrivalDate = "02-11-2017 16:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[13], departureDate = "02-11-2017 17:00",
                    arrivalDate = "02-11-2017 20:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[12], departureDate = "04-11-2017 13:00",
                    arrivalDate = "04-11-2017 16:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[13], departureDate = "04-11-2017 17:00",
                    arrivalDate = "04-11-2017 20:00", seatsLeft = 100, price = 1099 },
                //Bergen - Warszawa
                new Schedule { route = routes[14], departureDate = "02-11-2017 21:00",
                    arrivalDate = "03-11-2017 01:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[15], departureDate = "03-11-2017 07:00",
                    arrivalDate = "03-11-2017 11:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[14], departureDate = "04-11-2017 21:00",
                    arrivalDate = "05-11-2017 01:00", seatsLeft = 100, price = 1099 },
                new Schedule { route = routes[15], departureDate = "05-11-2017 07:00",
                    arrivalDate = "05-11-2017 11:00", seatsLeft = 100, price = 1099 }

            };

            //legg alle routene inn i databasen
            routes.ForEach(r => context.Routes.Add(r));
            //legg alle schedules inn i databasen
            schedules.ForEach(s => context.Schedules.Add(s));

            base.Seed(context);
        }
    }
}