using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Database;
using Example.CORE.Enums;
using Example.Entity.ComplexType;

namespace Example.Entity.Entity
{
    [Table("Vehiscles")]
    public class Vehicles: IEntity
    {
        [Key]
        public int ID { get; set; }
        public VehicleType VehicleType { get; set; } = VehicleType.Car;
        public Color VehicleColor { get; set; }
        public  LightStatuType Light { get; set; }
        public int UserID { get; set; }
        public bool Wheels { get; set; }

        public static implicit operator Vehicles(Car v)
        {
            return new Vehicles
            {
                Light = v.Light,
                VehicleType = VehicleType.Car,
                VehicleColor = v.Color,
                Wheels = v.Wheels 



            };
        }




        public static implicit operator Vehicles(Vehicle v)
        {
            return new Vehicles
            {
                
                VehicleType = VehicleType.Car,
                VehicleColor = v.Color,
               



            };
        }


         
    }
}
