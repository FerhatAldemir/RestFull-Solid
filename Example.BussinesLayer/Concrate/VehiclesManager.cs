using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
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
    public class VehiclesManager : IVehicles
    {
        readonly Dictionary<Type, dynamic> VehiclesProviders;
        public VehiclesManager(IServiceProvider serviceProvider)
        {
            VehiclesProviders = new Dictionary<Type, dynamic>();
            VehiclesProviders.Add(typeof(Car), serviceProvider.GetService(typeof(CarManager)));
            VehiclesProviders.Add(typeof(Boat), serviceProvider.GetService(typeof(BoatManager)));
            VehiclesProviders.Add(typeof(Bus), serviceProvider.GetService(typeof(BusManager)));
        }

        public ServiceResult<T> addVehicle<T>(T Model)
        {
            try
            {

                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];


                return ServiceResult<T>.SuccessResult(Provider.addVehicle(Model), "Ekleme İşlemi Başarılı Oldu");

            }
            catch (undefinedException ex)
            {

                return ServiceResult<T>.FailureResult(ex.Message);

            }
            catch (Exception ex)
            {
                return ServiceResult<T>.FailureResult("Yeni Araç Ekleme İşlemi Başarısız Oldu");


            }

        }

        public Vehicle test()
        {

            return new Car();

        }

        public ServiceResult<List<T>> GetVehiclesByColor<T>(Color Color)
        {
            try
            {
                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];

                var Data = Provider.GetVehiclesByColor(Color).OfType<T>();

                return ServiceResult<List<T>>.SuccessResult(Data.ToList(), "");

            }
            catch (undefinedException Ex)
            {

                return ServiceResult<List<T>>.FailureResult(Ex.Message);

            }
            catch
            {

                return ServiceResult<List<T>>.FailureResult("İstek Başarısız Oldu");

            }

        }

        public ServiceResult<T> RemoveVehicle<T>(int ID)
        {

            try
            {
                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];
                string Message = "";
                var RemovedItem = Provider.RemoveVehicle(ID, out Message);

                return ServiceResult<T>.SuccessResult(RemovedItem, Message);

            }
            catch (undefinedException Ex)
            {
                return ServiceResult<T>.FailureResult(Ex.Message);
            }
            catch (Exception ex)
            {
                return ServiceResult<T>.FailureResult("Silme İşlemi Başarısız Oldu");


            }





        }



        public ServiceResult<T> togglelights<T>(int ID)
        {
            try
            {
                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];
                var Message = "";
                var Item = Provider.togglelights(ID, out Message);


                return ServiceResult<T>.SuccessResult(Item, Message);

            }
            catch (undefinedException ex)
            {

                return ServiceResult<T>.FailureResult(ex.Message);
            }
            catch (Exception ex)
            {

                return ServiceResult<T>.FailureResult("Farlar Kapatıldı");

            }





        }

        public ServiceResult<List<T>> getAll<T>()
        {
            try
            {
                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];
                string Message = "";
                var Data = Provider.GetALL(out Message).OfType<T>();

                return ServiceResult<List<T>>.SuccessResult(Data.ToList(), Message);

            }
            catch (undefinedException Ex)
            {

                return ServiceResult<List<T>>.FailureResult(Ex.Message);

            }
            catch
            {

                return ServiceResult<List<T>>.FailureResult("İstek Başarısız Oldu");

            }
        }

        public ServiceResult<T> get<T>(int ID)
        {
            try
            {
                IVehicleFactory<T> Provider = VehiclesProviders[typeof(T)];
                string Message = "";
                var Data = Provider.Get(ID,out Message);

                return ServiceResult<T>.SuccessResult(Data, Message);

            }
            catch (undefinedException Ex)
            {

                return ServiceResult<T>.FailureResult(Ex.Message);

            }
            catch
            {

                return ServiceResult<T>.FailureResult("İstek Başarısız Oldu");

            }
        }
    }
}
