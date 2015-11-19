using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class CreateGroup
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List <SubCategories> subCategories { get; set; }

        public CreateGroup()
        {
            this.products = new List<Product>();
            
        }
    }
}