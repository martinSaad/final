


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class CreateGroup
    {
        public IEnumerable<object> products { get; set; }
        public List<ProductCategory> categories { get; set; }
        public List<SubCategory> subCategories { get; set; }

        public CreateGroup()
        {
            this.categories = new List<ProductCategory>();
            this.subCategories = new List<SubCategory>();
            this.products = new List<object>();

        }
    }
}

