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
    internal class BoatManager : VehicleManagerAbstract
    {
        public BoatManager(IVehiclesRepoStory vehiclesRepoStory, IHttpContextAccessor acx) : base(vehiclesRepoStory, acx, CORE.Enums.VehicleType.Boat)
        {
        }

        public override ServiceResult<bool> togglelights(int ID)
        {
            return ServiceResult<bool>.FailureResult("Far Aç/Kapat İşlemi Başarısız Oldu");
        }
    }
}
