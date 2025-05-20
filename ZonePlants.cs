using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Entities
{
    public class ZonePlants
    {
        public int zone_id { get; set; }
        public Zones Zone { get; set; }
        public int plant_id {  get; set; }
        public PlantSpecies PlantSpecies { get; set; }
        public Density density { get; set; }  
    }
}
