﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entity.Entity;
using Example.CORE.Enums;
using Example.CORE.Model;
using Example.Entity.ComplexType;

namespace Example.BussinesLayer.Abstract
{
    public interface IVehicles
    {

        public ServiceResult<List<T>> GetVehiclesByColor<T>(Color Color);
        public ServiceResult<List<T>> getAll<T>();
        public ServiceResult<T> get<T>(int ID);
        public ServiceResult<T> togglelights<T>(int ID);
        public ServiceResult<T> addVehicle<T>(T Model);
        public ServiceResult<T> RemoveVehicle<T>(int ID);

    }
}
