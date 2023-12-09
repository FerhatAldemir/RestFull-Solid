using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.CORE.Enums;
using Example.Entity.Entity;
using Example.BussinesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class VehiclesController : ControllerBase
    {
        public IVehicles Vehicles { get; }

        public VehiclesController(IVehicles vehicles)
        {
            Vehicles = vehicles;
        }


        [HttpGet("{color:int}")]
        public IActionResult getCars(Color color) => Ok(Vehicles.GetVehiclesByColor(color, VehicleType.Car));
        [HttpGet("{color:int}")]
        public IActionResult getBuses(Color color) => Ok(Vehicles.GetVehiclesByColor(color, VehicleType.Bus));
        [HttpGet("{color:int}")]
        public IActionResult getBoats(Color color) => Ok(Vehicles.GetVehiclesByColor(color, VehicleType.Boat));




        [HttpPost]
        public IActionResult addVehicle(Vehicles Vehicle) => Ok(Vehicles.addVehicle(Vehicle));

        //Normalde Güncelleme İşlemi Olduğu için Put olmalıyıdı bu attr ama gönderilen metinde post yapıalcak dendiği için post yaptım
        [HttpPost("{carId:int}")]
        public IActionResult carLightControl(int carId) => Ok(Vehicles.togglelights(carId, VehicleType.Car));


        [HttpDelete("{carId:int}")]
        public IActionResult removeCar(int carId) => Ok(Vehicles.RemoveVehicle(carId, VehicleType.Car));
         



    }
}
