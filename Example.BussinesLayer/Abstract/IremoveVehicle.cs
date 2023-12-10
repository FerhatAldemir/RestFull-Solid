using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Abstract
{
    internal interface IremoveVehicle<T>
    {
        public T RemoveVehicle(int ID, out string Message);
    }
}
