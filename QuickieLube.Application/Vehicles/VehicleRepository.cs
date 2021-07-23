using QuickieLube.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickieLube.Application.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> _vehicles;

        public VehicleRepository()
        {
            _vehicles = new List<Vehicle>()
            {
                new Vehicle(){Id="ON-AVX",Name="Ford",Description="2015 Ford",VIN="5GAK",Fleet="",LastService=DateTime.Now.AddDays(-10)},
                new Vehicle(){Id="TX-K51",Name="BMW",Description="2011 BMW",VIN="5ABC",Fleet="",LastService=DateTime.Now.AddDays(-11)},
                new Vehicle(){Id="TX-H71T",Name="mercedes",Description="2013 mercedes",VIN="6KDE",Fleet="",LastService=DateTime.Now.AddDays(-2)},
                new Vehicle(){Id="TX-511R",Name="BMW",Description="2021 BMW",VIN="9JIF",Fleet="Poland",LastService=DateTime.Now.AddDays(-4)},
                new Vehicle(){Id="TX-122G",Name="Ford",Description="2008 Ford",VIN="25TY",Fleet="Hertz",LastService=DateTime.Now.AddDays(-3)},
                new Vehicle(){Id="TX-2588QW",Name="BMW",Description="2004 BMW",VIN="AA258",Fleet="",LastService=DateTime.Now.AddDays(-20)},
                new Vehicle(){Id="ON-AV12X",Name="mercedes",Description="2007 mercedes",VIN="2GUE",Fleet="",LastService=DateTime.Now.AddDays(-5)},
            };
        }

        public VehicleRepository(List<Vehicle> vehicles)
        {
            _vehicles = vehicles;
        }

        public IEnumerable<Vehicle> SearchVehicle(string searchParams)
        {

            if (String.IsNullOrEmpty(searchParams))
            {
                return _vehicles.OrderByDescending(s => s.LastService);
            }

            return _vehicles.Where(s => s.Id.Contains(searchParams, StringComparison.OrdinalIgnoreCase) ||
                                           s.Name.Contains(searchParams, StringComparison.OrdinalIgnoreCase) ||
                                           s.VIN.Contains(searchParams, StringComparison.OrdinalIgnoreCase))
                                           .OrderByDescending(s => s.LastService);
        }

        public Vehicle EditVehicle(string id)
        {
            return _vehicles.FirstOrDefault(s => s.Id == id);
        }

        public Vehicle UpdateVehicle(Vehicle updatedVehicle)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(s => s.Id == updatedVehicle.Id);

            if (vehicle != null)
            {
                vehicle.Name = updatedVehicle.Name;
                vehicle.Description = updatedVehicle.Description;
                vehicle.VIN = updatedVehicle.VIN;
                vehicle.Fleet = updatedVehicle.Fleet;
                vehicle.LastService = updatedVehicle.LastService;
            }

            return vehicle;
        }
    }
}
