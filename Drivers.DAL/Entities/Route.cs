using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class Route :BaseEntity
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
