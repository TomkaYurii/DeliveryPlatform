using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class DriverLicense : BaseEntity
    {
        public int LicenseId { get; set; }
        public string Type { get; set; }// A A1 B B1...
        public DateTime ExpiryDate { get; set; }


    }
}
