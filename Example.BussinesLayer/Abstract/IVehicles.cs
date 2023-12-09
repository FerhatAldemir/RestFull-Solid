using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entity.Entity;
using Example.CORE.Enums;
using Example.CORE.Model;

namespace Example.BussinesLayer.Abstract
{
    public interface IVehicles
    {

        public ServiceResult<List<Vehicles>> GetVehiclesByColor(Color Color,VehicleType VehicleType);
        public ServiceResult<bool> togglelights(int ID, VehicleType VehicleType);
        public ServiceResult<Vehicles> addVehicle(Vehicles Model);
        public ServiceResult<Vehicles> RemoveVehicle(int ID, VehicleType VehicleType);

    }
}
