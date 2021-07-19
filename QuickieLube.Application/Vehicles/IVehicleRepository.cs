using QuickieLube.Domain.Vehicles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickieLube.Application.Vehicles
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> SearchVehicle(string searchParams);
        Vehicle EditVehicle(string id);
        Vehicle UpdateVehicle(Vehicle updatedVehicle);
    }
}