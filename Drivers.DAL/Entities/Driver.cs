﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public  class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Experience { get; set; }

        public int Car_Id { get; set; }
        public int DriverLicense_Id { get; set; }
    }
}
