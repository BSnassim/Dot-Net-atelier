using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }
        [Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
                
        [EmailAddress]
        public string EmailAddress { get; set; }

        public virtual FullName FullName { get; set; }

        [RegularExpression(@"^\d{8}$")]
        public string TelNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return $"FirstName: {FullName.FirstName} LastName: {FullName.LastName}";
        }

        public bool CheckProfile(string firstname, string lastname, string emailAddress = null)
        {
            return (emailAddress != null) ? firstname == FullName.FirstName && lastname == FullName.LastName && emailAddress == EmailAddress
            : firstname == FullName.FirstName && lastname == FullName.LastName;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }


    }
}
