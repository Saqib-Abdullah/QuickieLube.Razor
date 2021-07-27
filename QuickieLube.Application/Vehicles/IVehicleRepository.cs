using QuickieLube.Domain.Vehicles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickieLube.Application.Vehicles
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> SearchVehicle(string searchParams);
        Vehicle GetVehicleById(string id);
        void EditVehicle(Vehicle editedVehicle);
    }
}