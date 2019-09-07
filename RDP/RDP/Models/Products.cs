using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDP.Models
{
    // 2
    public class Products
    {

        public string Id { get; set; }
      
        public string SKU { get; set; }
       
        public string Name { get; set; }
      
        public string Description { get; set; }
       
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
