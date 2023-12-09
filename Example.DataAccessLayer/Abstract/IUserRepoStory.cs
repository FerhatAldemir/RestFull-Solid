using Example.CORE.Abstract;
using Example.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccessLayer.Abstract
{
    public interface IUserRepoStory : IRepoStoryCore<User, DataContext>
    {
    }
}
