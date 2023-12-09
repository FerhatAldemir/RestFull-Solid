using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Concrate;
using Example.Entity.Entity;
using Example.DataAccessLayer.Abstract;
namespace Example.DataAccessLayer.Concrate
{
    public class VehiclesRepoStoryManager :   RepoStoryManager<Vehicles,DataContext>, IVehiclesRepoStory
    {
    }
}
