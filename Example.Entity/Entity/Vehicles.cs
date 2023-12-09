using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CORE.Database;
using Example.CORE.Enums;


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
        public string Mark { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}
