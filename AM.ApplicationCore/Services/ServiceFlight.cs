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
            return _unitOfWork.Repository<Staff>().GetAll()
        }
    }
}
