using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Facilities
    {
        public int id { get; set; }
        public int zone_id { get; set; }
        public string type { get; set; }
        public string material { get; set; }
        public string condition { get; set; }
        public DateTime installed_on { get; set; }
        public Zones Zone { get; set; }
    }
}
