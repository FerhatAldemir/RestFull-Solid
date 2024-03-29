﻿using Example.BussinesLayer.Abstract;
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
    internal class BoatManager : IVehicleFactory<Boat>
    {
        public BoatManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor Acx)
        {
            VehiclesRepoStory = vehiclesRepoStory;
            acx = Acx;
        }
        public IVehiclesRepoStory VehiclesRepoStory { get; }
        public IHttpContextAccessor acx { get; }
        public Boat addVehicle(Vehicle Model)
        {
            Vehicles TableModel = (Boat)Model;
            var UserId = acx.HttpContext.GetUserId();
            TableModel.UserID = UserId;
            TableModel.VehicleType = VehicleType.Boat;
            VehiclesRepoStory.Add(TableModel);
            return TableModel;
        }

        public Boat Get(int ID, out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            Boat Vehicles = VehiclesRepoStory.Get(x => x.VehicleType == VehicleType.Boat && x.ID == ID && x.UserID == UserId);
            if (Vehicles == null) throw new undefinedException($"{ID} Referanslı Tekne Türünde bir Araç Bulunamadı");
            Message = $"{ID} Referanslı Tekne Türündeki Araç";
            return Vehicles;
        }

        public IEnumerable<Boat> GetALL(out string Message)
        {
            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Boat> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Boat && x.UserID == UserId).Select(x => (Boat)x);
            if (!Vehicles.Any()) throw new undefinedException("Tekne Türünde bir Araç Bulunamadı");
            Message = "Tekne Türündeki Tüm Araçlar";
            return Vehicles;
        }

        public IEnumerable<Boat> GetVehiclesByColor(Color Color)
        {
            int UserId = acx.HttpContext.GetUserId();
            IEnumerable<Boat> Vehicles = VehiclesRepoStory.GetAll(x => x.VehicleType == VehicleType.Boat && x.VehicleColor == Color && x.UserID == UserId).Select(x=> (Boat)x);
            if (!Vehicles.Any()) throw new undefinedException("Tekne Türünde bir Araç Bulunamadı");
            return Vehicles;
        }
 

        
    }
}
