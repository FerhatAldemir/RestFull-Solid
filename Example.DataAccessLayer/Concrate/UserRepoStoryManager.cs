using Example.CORE.Concrate;
using Example.DataAccessLayer.Abstract;
using Example.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccessLayer.Concrate
{
    public class UserRepoStoryManager : RepoStoryManager<User, DataContext>, IUserRepoStory
    {
    }
}
