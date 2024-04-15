using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork _unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<Passenger> GetPlanePassengers(Plane plane)
        {
            return _unitOfWork.Repository<Plane>()
                .GetById(plane.PlaneId)
                .Flights
                .SelectMany(f => f.Tickets)
                .Select(t => t.Passenger)
                .ToList();
        }
        public void DeleteTenYearOldPlanes()
        {
            foreach (Plane p in GetMany(p => (DateTime.Now.Year - p.ManufacturerDate.Year) > 10).ToList())
            {
                Delete(p);
                Commit();
            }

        }
    }
}
