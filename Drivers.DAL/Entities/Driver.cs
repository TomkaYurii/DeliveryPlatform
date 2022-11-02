using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public  class Driver : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Driver_Id { get; set; }
        public int Car_Id { get; set; }
        public int DriverLicense_Id { get; set; }     
        public int Country_Id { get; set; }
        public int Rating_Id { get; set; }
        public int Gallery_id { get; set; }
    }
}
