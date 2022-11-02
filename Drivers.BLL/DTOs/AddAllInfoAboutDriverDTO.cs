using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.DTOs
{
    public class AddAllInfoAboutDriverDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Experience { get; set; }


        // public int LicenseId { get; set; }
        public string Type { get; set; }
        public DateTime ExpiryDate { get; set; }


        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Max_weight { get; set; }



    }
}
