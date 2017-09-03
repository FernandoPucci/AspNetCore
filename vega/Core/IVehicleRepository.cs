using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);


        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}
