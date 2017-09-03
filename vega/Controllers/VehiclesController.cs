using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {

        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnityOfWork unityOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource saveVehicleResource)
        {
            //Model Validations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);

            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);

            await unityOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);

        }

        [HttpPut("{id}")] //api/vehicle/{id}
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveVehicleResource saveVehicleResource)
        {
            //Model Validations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource, vehicle);

            vehicle.LastUpdate = DateTime.Now;

            await unityOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
            {
                return NotFound();
            }
            repository.Remove(vehicle);

            await unityOfWork.CompleteAsync();

            return NoContent();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {

            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }
    }
}