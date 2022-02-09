using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI.Entities
{
    public class Stuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ElectromarketId { get; set; }
        public virtual Electromarket Electromarket { get; set; }

    }
}
