using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Product
    {
        public string objectId { get; set; }
        public string title { get; set; }
        public string image { get; set; } //link to image
        public Manufacturer manufacturer { get; set; }
        public List<Business> businesses { get; set; }

        public Product()
        {
            businesses = new List<Business>();
        }
    }
}

