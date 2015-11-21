


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class CreateGroup
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<ProductCategory> categories { get; set; }
        public IEnumerable<SubCategory> subCategories { get; set; }

        public CreateGroup()
        {
            this.categories = new List<ProductCategory>();
            this.subCategories = new List<SubCategory>();
            this.products = new List<Product>();

        }
    }
}

