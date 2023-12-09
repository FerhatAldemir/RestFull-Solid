using Example.CORE.Abstract;
using Example.CORE.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Example.Entity.Entity;

namespace Example.DataAccessLayer.Abstract
{
    public interface IVehiclesRepoStory:IRepoStoryCore<Vehicles,DataContext> 
        
    {
    }
}
