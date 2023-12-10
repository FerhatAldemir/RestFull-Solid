using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.BussinesLayer.Abstract
{
    public interface IToggleLight<T>
    {
        public T togglelights(int ID, out string Message);
    }
}
