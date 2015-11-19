using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class ProductCategory
    {
        public string objectId { get; set; }
        public string name { get; set; }
        public List<SubCategory> subCategory { get; set; }

        public ProductCategory()
        {
            subCategory = new List<SubCategory>();
        }
    }
}