﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.CORE.Enums;
using Example.Entity.Entity;
using Example.BussinesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Example.Entity.ComplexType;
using Example.CORE.Model;

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

        [HttpGet]
        public ServiceResult<List<Car>> getAllCar() => Vehicles.getAll<Car>();
        [HttpGet("{ID:int}")]
        public ServiceResult<Car> getCar(int ID) => Vehicles.get<Car>(ID);
        [HttpGet("{color:int}")]
        public ServiceResult<List<Car>> getCars(Color color) => Vehicles.GetVehiclesByColor<Car>(color);
        [HttpGet]
        public ServiceResult<List<Bus>> getAllBus() => Vehicles.getAll<Bus>();
        [HttpGet("{ID:int}")]
        public ServiceResult<Bus> getBus(int ID) => Vehicles.get<Bus>(ID);
        [HttpGet("{color:int}")]
        public ServiceResult<List<Bus>> getBuses(Color color) => Vehicles.GetVehiclesByColor<Bus>(color);

        [HttpGet]
        public ServiceResult<List<Boat>> getAllBoat() => Vehicles.getAll<Boat>();
        [HttpGet("{ID:int}")]
        public ServiceResult<Boat> getBoat(int ID) => Vehicles.get<Boat>(ID);
        [HttpGet("{color:int}")]
        public ServiceResult<List<Boat>> getBoats(Color color) => Vehicles.GetVehiclesByColor<Boat>(color);





        [HttpPost]
        public ServiceResult<Car> addCar(Car Vehicle) => Vehicles.addVehicle<Car>(Vehicle);
        [HttpPost]
        public ServiceResult<Bus> addBus(Bus Vehicle) => Vehicles.addVehicle<Bus>(Vehicle);
        [HttpPost]
        public ServiceResult<Boat> addBoat(Boat Vehicle) => Vehicles.addVehicle<Boat>(Vehicle);

        //Normalde Güncelleme İşlemi Olduğu için Put olmalıyıdı bu attr ama gönderilen metinde post yapıalcak dendiği için post yaptım
        [HttpPost("{carId:int}")]
        public IActionResult carLightControl(int carId) => Ok(Vehicles.togglelights<Car>(carId));
        [HttpPost("{carId:int}")]
        public IActionResult BusLightControl(int carId) => Ok(Vehicles.togglelights<Bus>(carId));

        [HttpDelete("{carId:int}")]
        public IActionResult removeCar(int carId) => Ok(Vehicles.RemoveVehicle<Car>(carId));
        [HttpDelete("{carId:int}")]
        public IActionResult removeBus(int carId) => Ok(Vehicles.RemoveVehicle<Bus>(carId));
        [HttpDelete("{carId:int}")]
        public IActionResult removeBoat(int carId) => Ok(Vehicles.RemoveVehicle<Boat>(carId));




    }
}