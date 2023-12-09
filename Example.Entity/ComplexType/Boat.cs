using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Enums;
using Example.Entity.Entity;

namespace Example.Entity.ComplexType
{
    public class Boat:Vehicle
    {
        public static implicit operator Boat(Vehicles Table)
        {
            if (Table == null) return null;
            return new Boat
            {
                Color = Table.VehicleColor,
                ID = Table.ID,

            };


        }
    }
}
