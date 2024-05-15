using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork _unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<Flight> GetFlights(int n)
        {
            return _unitOfWork.Repository<Plane>().GetAll()
                .OrderByDescending(p=>p.PlaneId)
                .Take(n)
                .SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate)
                .ToList();
        }
        public Boolean PlacesAvailable(Flight flight, int n)
        {
            int capacity = flight.FlightPlane.Capacity;
            int reserved = flight.Tickets.Count();
            return capacity - reserved >= n;
        }
        public IList<Staff> GetStaffs(int flightId)
        {
            //return _unitOfWork.Repository<Staff>().GetAll()
            return null;
        }
        public List<Passenger> PlanePassengers(Plane plane, DateTime date)
        {
            return _unitOfWork.Repository<Passenger>().GetAll()
                .Where(p=>p.Tickets.Any(t=>t.Flight.FlightPlane.PlaneId == plane.PlaneId && t.Flight.FlightDate == date))
                .ToList();
        }
        public void PassengerCountBetweenDates(DateTime start, DateTime end)
        {
            var query = GetMany(f => f.FlightDate >= start && f.FlightDate <= end)
                .SelectMany(f => f.Tickets)
                .GroupBy(t => t.Flight.FlightDate)
                .Select(g => new { Date = g.Key, Count = g.Count() });
            foreach (var item in query)
            {
                Console.WriteLine($"Date: {item.Date}, Nombre de passengers: {item.Count}");
            }
        }
    }
}
