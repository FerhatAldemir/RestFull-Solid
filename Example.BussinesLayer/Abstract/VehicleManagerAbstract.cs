using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;

namespace Example.BussinesLayer.Abstract
{
    public abstract class VehicleManagerAbstract
    {
        public IVehiclesRepoStory VehicleRepoStory;
        private readonly IHttpContextAccessor acx;
        private readonly VehicleType VehicleType;

        public VehicleManagerAbstract(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor acx, VehicleType VehicleType_)
        {
            VehicleRepoStory = vehiclesRepoStory;
            this.acx = acx;
            VehicleType = VehicleType_;
        }

        public ServiceResult<List<Vehicles>> GetVehiclesByColor(Color Color)
        {
            ServiceResult<List<Vehicles>> Result = null;
            try
            {

                var UserId = acx.HttpContext.GetUserId();
                var Vehicles = VehicleRepoStory.GetAll(x => x.VehicleType == VehicleType && x.VehicleColor == Color && x.UserID == UserId);

                Result = ServiceResult<List<Vehicles>>.SuccessResult(Vehicles.ToList(), "Renkli Araçlar");

            }
            catch (Exception Ex)
            {

                Result = ServiceResult<List<Vehicles>>.FailureResult($"İşlem Gerçekleştirilmedi", 501);


            }
            finally
            {
                acx.HttpContext.Response.StatusCode = Result.StatusCode;


            }



            return Result;

        }

        public ServiceResult<Vehicles> RemoveVehicle(int ID)
        {
            ServiceResult<Vehicles> Result = null;
            try
            {
                var UserId = acx.HttpContext.GetUserId();

                if (VehicleRepoStory.Any(x => x.ID == ID && x.UserID == UserId && x.VehicleType == VehicleType))
                {
                    var RemovedItem = VehicleRepoStory.Remove(x => x.ID == ID && x.UserID == UserId && x.VehicleType == VehicleType);

                    Result = ServiceResult<Vehicles>.SuccessResult(RemovedItem, $"{ID} Referanslı Araç Silinmiştir");

                }
                else
                    Result = ServiceResult<Vehicles>.FailureResult($"{ID} Referansına Ait Araç Bulunamadı");

            }
            catch (Exception)
            {

                Result = ServiceResult<Vehicles>.FailureResult($"İşlem Gerçekleştirilmedi", 501);


            }
            finally
            {

                acx.HttpContext.Response.StatusCode = Result.StatusCode;

            }


            return Result;


        }


        public ServiceResult<Vehicles> addVehicle(Vehicles Model)
        {
            try
            {
                var UserId = acx.HttpContext.GetUserId();
                Model.UserID = UserId;
                VehicleRepoStory.Add(Model);
                return ServiceResult<Vehicles>.SuccessResult(Model, "Araç Başarıyla Eklendi");

            }
            catch (Exception ex)
            {


                return ServiceResult<Vehicles>.FailureResult("İşlem Başarısız Oldu");

            }



        }




        public virtual ServiceResult<bool> togglelights(int ID)
        {
            try
            {
                var UserId = acx.HttpContext.GetUserId();
                var VehicleItem = VehicleRepoStory.Get(x => x.ID == ID && x.VehicleType == VehicleType && x.UserID == UserId);
                if (VehicleItem == null) throw new undefinedException("Farını Kapatmak İstediğiniz Araç Bulunamadı");
                if(VehicleItem.Light == LightStatuType.Close)
                {
                    VehicleItem.Light = LightStatuType.Open;
                    VehicleRepoStory.Update(VehicleItem);
                    return ServiceResult<bool>.SuccessResult(true,"Farlar Açıldı");
                }
                else
                {
                    VehicleItem.Light = LightStatuType.Close;
                    VehicleRepoStory.Update(VehicleItem);
                    return ServiceResult<bool>.SuccessResult(true, "Farlar Kapatıldı");

                }

            }
            catch (undefinedException Ex)
            {
                return ServiceResult<bool>.FailureResult(Ex.Message);

            }
            catch (Exception ex)
            {

                return ServiceResult<bool>.FailureResult("Far Aç/Kapat işlemi Başarısız Oldu");

            }
         


            
        }

    }
}
