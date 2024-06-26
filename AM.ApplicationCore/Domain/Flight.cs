﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? AirlineLogo { get; set; }
        [Key]
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        [ForeignKey("FlightPlane")]
        public int PlaneId { get; set; }
        public virtual Plane FlightPlane { get; set; }
        //public ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return $"FlightId: {FlightId}, Destination: {Destination}, FlightDate: {FlightDate}";
        }

    }
}
