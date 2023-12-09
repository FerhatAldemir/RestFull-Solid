using Example.BussinesLayer.Abstract;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Concrate
{
    internal class BusManager : VehicleManagerAbstract
    {
        public BusManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor acx) : base(vehiclesRepoStory, acx, CORE.Enums.VehicleType.Bus)
        {
        }

        public override ServiceResult<bool> togglelights(int ID)
        {
            return base.togglelights(ID);
        }
    }
}
