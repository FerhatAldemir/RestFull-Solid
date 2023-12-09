using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.BussinesLayer.Abstract;
using Example.CORE.Enums;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;

namespace Example.BussinesLayer.Concrate
{
    internal class CarManager : VehicleManagerAbstract
    {
        public CarManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor acx) : base(vehiclesRepoStory, acx, VehicleType.Car)
        {
        }

        public override ServiceResult<bool> togglelights(int ID)
        {
            return base.togglelights(ID);
        }
    }
}
