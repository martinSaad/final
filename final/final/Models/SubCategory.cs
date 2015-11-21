using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class SubCategory : Convertor
    {
        public string objectId { get; set; }
        public string name { get; set; }
        public List<Product> products { get; set; }

        public SubCategory()
        {
            products = new List<Product>();
        }
    }
}