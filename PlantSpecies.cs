using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Entities
{
    public class PlantSpecies
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string latin_name {  get; set; }
        public bool is_protected {  get; set; }
        public string description {  get; set; }
        

        public ICollection<ZonePlants> ZonePlants { get; set; }
    }
}
