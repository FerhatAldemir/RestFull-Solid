using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Enums;
using Example.Entity.Entity;

namespace Example.Entity.ComplexType
{
    public class Bus:Vehicle
    {
      
        public static implicit operator Bus(Vehicles Table)
        {
            if (Table == null) return null;
            return new Bus
            {
                Color = Table.VehicleColor,
                ID = Table.ID,
              
            };


        }

    }
}
