using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Example.Entity.ComplexType;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;

namespace Example.BussinesLayer.Concrate
{
    internal class CarManager : IVehicleFactory<Car>
    {
        public CarManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor Acx)
        {
            VehiclesRepoStory = vehiclesRepoStory;
            acx = Acx;
        }

        public IVehiclesRepoStory VehiclesRepoStory { get; }
        public IHttpContextAccessor acx { get; }

        public Car addVehicle(Car Model)
        {
            Vehicles TableModel = Model;
            var UserId = acx.HttpContext.GetUserId();
            TableModel.UserID = UserId;
            VehiclesRepoStory.Add(TableModel);
            return TableModel;
        }

        public List<Car> GetVehiclesByColor(Color Color)
        {

            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Car> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Car && x.VehicleColor == Color && x.UserID == UserId).Select(x=> (Car)x);
            if (!Vehicles.Any())throw new undefinedException("Araba Türünde bir Araç Bulunamadı");
            return Vehicles.ToList();


        }


        public Car Get(int ID, out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            Car Vehicles = VehiclesRepoStory.Get(x => x.VehicleType == VehicleType.Car && x.ID == ID && x.UserID == UserId);
            if (Vehicles == null) throw new undefinedException($"{ID} Referanslı Araba Türünde bir Araç Bulunamadı");
            Message = $"{ID} Referanslı Araba Türündeki Araç";
            return Vehicles;
        }

        public List<Car> GetALL(out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Car> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Car && x.UserID == UserId).Select(x => (Car)x);
            if (!Vehicles.Any()) throw new undefinedException("Araba Türünde bir Araç Bulunamadı");
            Message = "Araba Türündeki Tüm Araçlar";
            return Vehicles.ToList();
        }

        public Car RemoveVehicle(int ID,out string Message)
        {
            var UserId = acx.HttpContext.GetUserId();
            var RemovedItem = VehiclesRepoStory.Remove(x => x.UserID == UserId && x.ID == ID && x.VehicleType == VehicleType.Car);
            if (object.Equals(RemovedItem, null)) throw new undefinedException($"Listenizde {ID} Referanslı Bir Araç Bulunamadı");
            Message = $"{ID} Referanslı Araba Silindi";
            return RemovedItem;
        }

        public Car togglelights(int ID,out string Message)
        {
            var UserId = acx.HttpContext.GetUserId();
            Vehicles VehicleItem = VehiclesRepoStory.Get(x => x.ID == ID && x.VehicleType == VehicleType.Car && x.UserID == UserId);
            if (VehicleItem == null) throw new undefinedException("Farını Kapatmak İstediğiniz Araç Bulunamadı");

            if (VehicleItem.Light == LightStatuType.Close)
            {
                VehicleItem.Light = LightStatuType.Open;
                Message = "Farlar Açıldı";

            }

            else
            {
                Message = "Farlar Kapatıldı";
                VehicleItem.Light = LightStatuType.Close;
            }
                
            VehiclesRepoStory.Update(VehicleItem);
            return VehicleItem;
        }


    }
}
