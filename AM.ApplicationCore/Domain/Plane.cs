using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing, Airbus }
    public class Plane
    {
        [Key]
        public int PlaneId { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufacturerDate { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"PlaneId: {PlaneId} , Capacity: {Capacity}, ManufacturerDate: {ManufacturerDate}, PlaneType: {PlaneType}";
        }

    }
}
