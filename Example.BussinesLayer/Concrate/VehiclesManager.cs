using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Concrate
{
    public class VehiclesManager : IVehicles
    {
        readonly Dictionary<VehicleType, VehicleManagerAbstract> Vehicles;
        public VehiclesManager(IServiceProvider serviceProvider)
        {
            Vehicles = new Dictionary<VehicleType, VehicleManagerAbstract>();
            Vehicles.Add(VehicleType.Car, (VehicleManagerAbstract)serviceProvider.GetService(typeof(CarManager))); ;
            Vehicles.Add(VehicleType.Boat, (VehicleManagerAbstract)serviceProvider.GetService(typeof(BoatManager)));
            Vehicles.Add(VehicleType.Bus, (VehicleManagerAbstract)serviceProvider.GetService(typeof(BusManager)));
        }

        public ServiceResult<Vehicles> addVehicle(Vehicles Model)
        {
            try
            {
                if (!Model.VehicleType.CheckEnumField()) throw new undefinedException("Lütfen Araç Türü Belirtiniz");
                if (!Model.VehicleColor.CheckEnumField()) throw new undefinedException("Lütfen Eklemek İstediğiniz Aracın Rengini Belirtiniz");

                return  Vehicles[Model.VehicleType].addVehicle(Model);

            }
            catch(undefinedException ex)
            {

                return ServiceResult<Vehicles>.FailureResult(ex.Message);

            }
            catch (Exception ex)
            {
                return ServiceResult<Vehicles>.FailureResult("Yeni Araç Ekleme İşlemi Başarısız Oldu");


            }
             
        }

        public ServiceResult<List<Vehicles>> GetVehiclesByColor(Color Color, VehicleType VehicleType)
        {
            try
            {

               return Vehicles[VehicleType].GetVehiclesByColor(Color);

            }
            catch
            {

                return ServiceResult<List<Vehicles>>.FailureResult("İstek Başarısız Oldu");

            }

        }

        public ServiceResult<Vehicles> RemoveVehicle(int ID, VehicleType VehicleType) => Vehicles[VehicleType].RemoveVehicle(ID);



        public ServiceResult<bool> togglelights(int ID, VehicleType VehicleType) => Vehicles[VehicleType].togglelights(ID);


    }
}
