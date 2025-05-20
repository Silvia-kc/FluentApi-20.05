using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Zones
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string type {  get; set; }
        public decimal area_ha {  get; set; }
        public ICollection<Facilities> Facilities { get; set; }
        public ICollection<ZonePlants> ZonePlants { get; set; }
    }
}
