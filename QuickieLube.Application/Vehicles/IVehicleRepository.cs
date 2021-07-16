using QuickieLube.Domain.Vehicles;
using System.Collections.Generic;

namespace QuickieLube.Application.Vehicles
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> SearchVehicle(string searchParams);
    }
}