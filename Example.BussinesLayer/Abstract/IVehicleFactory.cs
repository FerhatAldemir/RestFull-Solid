using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Enums;
using Example.CORE.Exception;
using Example.CORE.Model;
using Example.DataAccessLayer.Abstract;
using Example.Entity.ComplexType;
using Example.Entity.Entity;
using Microsoft.AspNetCore.Http;

namespace Example.BussinesLayer.Abstract
{
    public interface IVehicleFactory<T>
    {
        public  IEnumerable<T> GetVehiclesByColor(Color Color);
      
        public T addVehicle(Vehicle Model);  
        public IEnumerable<T> GetALL(out string Message);
        public T Get(int ID, out string Message);
    }


}
