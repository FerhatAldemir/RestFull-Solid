using Example.CORE.Model;
using Example.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Abstract
{
    public interface IUserService
    {
        public ServiceResult<User> Add(User Item);
        public ServiceResult<object> GetToken(string Username,string Password);
    }
}
