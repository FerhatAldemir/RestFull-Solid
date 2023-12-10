﻿using Example.BussinesLayer.Abstract;
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
        public IHttpContextAccessor Acx { get; }

        public VehiclesManager(IServiceProvider serviceProvider, IHttpContextAccessor acx)
        {
          
            ServiceProvider = serviceProvider;
            Acx = acx;
        }

        public ServiceResult<T> addVehicle<T>(T Model)
        {
            try
            {

                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();


                return Acx.SuccessResult(Provider.addVehicle(Model), "Ekleme İşlemi Başarılı Oldu",System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException ex)
            {

                return Acx.FailureResult<T>(ex.Message, System.Net.HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return Acx.FailureResult<T>("Yeni Araç Ekleme İşlemi Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);


            }

        }

      

        public ServiceResult<List<T>> GetVehiclesByColor<T>(Color Color)
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();

                var Data = Provider.GetVehiclesByColor(Color).OfType<T>();

                return Acx.SuccessResult(Data.ToList(), "", System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException Ex)
            {

                return Acx.FailureResult<List<T>>(Ex.Message, System.Net.HttpStatusCode.BadRequest);

            }
            catch
            {

                return Acx.FailureResult<List<T>>("İstek Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);

            }

        }

        public ServiceResult<T> RemoveVehicle<T>(int ID)
        {

            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
                string Message = "";
                var RemovedItem = Provider.RemoveVehicle(ID, out Message);

                return Acx.SuccessResult(RemovedItem, Message, System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException Ex)
            {
                return Acx.FailureResult<T>(Ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Acx.FailureResult<T>("Silme İşlemi Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);


            }





        }



        public ServiceResult<T> togglelights<T>(int ID)
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
                var Message = "";
                var Item = Provider.togglelights(ID, out Message);


                return Acx.SuccessResult(Item, Message, System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException ex)
            {

                return Acx.FailureResult<T>(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {

                return Acx.FailureResult<T>("Far Açma Kapama İşlemi Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);

            }





        }

        public ServiceResult<List<T>> getAll<T>()
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
                string Message = "";
                var Data = Provider.GetALL(out Message).OfType<T>();

                return Acx.SuccessResult(Data.ToList(), Message, System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException Ex)
            {

                return Acx.FailureResult<List<T>>(Ex.Message, System.Net.HttpStatusCode.BadRequest);

            }
            catch
            {

                return Acx.FailureResult<List<T>>("İstek Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);

            }
        }

        public ServiceResult<T> get<T>(int ID)
        {
            try
            {
                IVehicleFactory<T> Provider = ServiceProvider.GetService<IVehicleFactory<T>>() ?? throw new Exception();
                string Message = "";
                var Data = Provider.Get(ID,out Message);

                return Acx.SuccessResult(Data, Message, System.Net.HttpStatusCode.OK);

            }
            catch (undefinedException Ex)
            {

                return Acx.FailureResult<T>(Ex.Message, System.Net.HttpStatusCode.BadRequest);

            }
            catch
            {

                return Acx.FailureResult<T>("İstek Başarısız Oldu", System.Net.HttpStatusCode.InternalServerError);

            }
        }
    }
}
