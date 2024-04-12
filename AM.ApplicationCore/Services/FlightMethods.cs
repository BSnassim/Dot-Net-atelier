using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;


        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = plane =>
            {
                var query = from flight in Flights
                            where flight.FlightPlane == plane
                            select flight;
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            };
            DurationAverageDel = destination =>
            {
                var query = from f in Flights where f.Destination == destination select f.EstimatedDuration;
                return query.Average();
            };
        }
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();

            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        result.Add(Flights[i].FlightDate);
            //        Console.WriteLine(Flights[i].FlightDate);
            //    }

            //}
            //foreach (var item in Flights)
            //{
            //    if (item.Destination == destination)
            //    {
            //        result.Add(item.FlightDate);
            //        Console.WriteLine(item.FlightDate);
            //    }
            //}

            //LINQ queries

            return Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();

            //return (from f in Flights where f.Destination == destination select f.FlightDate).ToList();
        }

        public void GetFlights(Predicate<Flight> f)
        {
            foreach( var item in Flights)
            {
                if(f(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
         var query = from flight in Flights
                     where flight.FlightPlane == plane
                    select flight;
            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate);
            }

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var res = 0;
            foreach (var item in Flights)
            {
                if (item.FlightDate <= startDate.AddDays(7) && item.FlightDate >= startDate)
                    res = +1;
            }
            return res;
        }

        public double DurationAverage(string destination)
        {
            var query = from f in Flights where f.Destination == destination select f.EstimatedDuration;
            return query.Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            var list = new List<Flight>();
            // 
            throw new NotImplementedException();
        }

        //public List<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //var query = (from p in flight.Passengers where p.GetType() == typeof(Traveller) select p).OrderBy(p => p.BirthDate).Take(3);
        //    //return query.Cast<Traveller>().ToList();
        //    //lambda method
        //    return flight.Passengers
        //        .Where(p => p.GetType() == typeof(Traveller))
        //        .OrderBy(p => p.BirthDate)
        //        .Take(3).Cast<Traveller>().ToList();
        //}   
        public void DestinationGroupedFlights()
        {
            var query = from f in Flights group f by f.Destination;
            foreach (var group in query)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("FlightDate:"+item.FlightDate);
                }
            }
        }


    }
}
