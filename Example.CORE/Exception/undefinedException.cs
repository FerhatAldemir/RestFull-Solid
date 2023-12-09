using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.CORE.Exception
{
    public class undefinedException:System.Exception
    {
        public undefinedException(string message):base(message)
        {

        }
    }
}
