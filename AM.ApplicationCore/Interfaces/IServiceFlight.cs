using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        public IList<Flight> GetFlights(int n);
        public Boolean PlacesAvailable(Flight flight, int n);
        public IList<Staff> GetStaffs(int flightId);
    }
}
