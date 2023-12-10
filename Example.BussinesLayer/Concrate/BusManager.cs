using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Example.Entity.ComplexType;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Concrate
{
    internal class BusManager : IVehicleFactory<Bus>
    {
        public BusManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor Acx) 
        {
            VehiclesRepoStory = vehiclesRepoStory;
            acx = Acx;
        }
        public IVehiclesRepoStory VehiclesRepoStory { get; }
        public IHttpContextAccessor acx { get; }
        public Bus addVehicle(Bus Model)
        {
            Vehicles TableModel = Model;
            var UserId = acx.HttpContext.GetUserId();
            TableModel.UserID = UserId;
            TableModel.VehicleType = VehicleType.Bus;
            VehiclesRepoStory.Add(TableModel);
            return TableModel;
        }


        public Bus Get(int ID, out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            Bus Vehicles = VehiclesRepoStory.Get(x => x.VehicleType == VehicleType.Bus && x.ID == ID && x.UserID == UserId);
            if (Vehicles == null) throw new undefinedException($"{ID} Referanslı Otobüs Türünde bir Araç Bulunamadı");
            Message = $"{ID} Referanslı Otobüs Türündeki Araç";
            return Vehicles;
        }

        public List<Bus> GetALL(out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Bus> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Bus && x.UserID == UserId).Select(x => (Bus)x);
            if (!Vehicles.Any()) throw new undefinedException("Otobüs Türünde bir Araç Bulunamadı");
            Message = "Otobüs Türündeki Tüm Araçlar";
            return Vehicles.ToList();
        }

        public  List<Bus> GetVehiclesByColor(Color Color)
        {
            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Bus> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Bus && x.VehicleColor == Color && x.UserID == UserId).Select(x=> (Bus)x);
            if (!Vehicles.Any()) throw new undefinedException("Otobüs Türünde bir Araç Bulunamadı");
            return Vehicles.ToList();
        }

        public Bus RemoveVehicle(int ID,out string Message)
        {
            var UserId = acx.HttpContext.GetUserId();
            var RemovedItem = VehiclesRepoStory.Remove(x => x.UserID == UserId && x.ID == ID && x.VehicleType == VehicleType.Bus);
            if (object.Equals(RemovedItem, null)) throw new undefinedException($"Listenizde {ID} Referanslı Bir Araç Bulunamadı");
            Message = $"{ID} Referanslı Otobüs Silindi";
            return RemovedItem;
        }

        public Bus togglelights(int ID,out string Message)
        {
            var UserId = acx.HttpContext.GetUserId();
            Vehicles VehicleItem = VehiclesRepoStory.Get(x => x.ID == ID && x.VehicleType == VehicleType.Bus && x.UserID == UserId);
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
