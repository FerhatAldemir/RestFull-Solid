using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.Entity.ComplexType;
using Microsoft.Extensions.DependencyInjection;
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
         

        public IServiceProvider ServiceProvider { get; }

        public VehiclesManager(IServiceProvider serviceProvider)
        {
          
            ServiceProvider = serviceProvider;
        }

        public ServiceResult<T> addVehicle<T>(T Model)
        {
            try
            {

                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();


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

      

        public ServiceResult<List<T>> GetVehiclesByColor<T>(Color Color)
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();

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
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
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
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
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

                return ServiceResult<T>.FailureResult("Far Açma Kapama İşlemi Başarısız Oldu");

            }





        }

        public ServiceResult<List<T>> getAll<T>()
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
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
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
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
