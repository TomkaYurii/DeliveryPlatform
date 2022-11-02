using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public string Color {get; set; }

    }
}
