// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

//Plane p = new Plane { Capacity=1, ManufacturerDate=DateTime.Now, PlaneId=4, PlaneType=PlaneType.Boing};
//Passenger ps = new Passenger { FirstName="Nassim", LastName="BenSalah"};
//Staff staff = new Staff();
//Traveller tr = new Traveller();
//Console.WriteLine("My plane: "+p.ToString());
//Console.WriteLine("Passenger profile: "+ps.CheckProfile("Nassim","BenSalah"));
//ps.PassengerType();
//staff.PassengerType();
//tr.PassengerType();

//FlightMethods fm = new FlightMethods { Flights = TestData.listFlights };
//fm.GetFlightDates("Paris").ForEach(data => Console.WriteLine(data));
//Console.WriteLine(fm.DurationAverage("Paris"));
//fm.DestinationGroupedFlights();
//Console.WriteLine("Testing DELEGATES :");

//fm.FlightDetailsDel(fm.Flights[0].FlightPlane);
//Console.WriteLine("Avg duration:"+ fm.DurationAverageDel("Paris"));
//Console.WriteLine("dynamic filter");
//fm.GetFlights( a => a.EstimatedDuration == 200);
//Passenger passenger = new Passenger { FullName = new FullName{ FirstName = "nassim", LastName = "benSalah" } };
//Console.WriteLine(passenger);
//passenger.UpperFullName();
//Console.WriteLine(passenger);

AMContext context = new AMContext { };
//context.Flights.Add(TestData.flight2);
//context.SaveChanges();
Console.WriteLine(context.Flights.First().FlightPlane.Capacity);