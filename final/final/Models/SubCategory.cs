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

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            foreach (ParseObject s in objects)
            {
                SubCategory subCategory = new SubCategory();
                subCategory.objectId = s.ObjectId;
                subCategory.name = s.Get<string>(Constants.NAME);

                Product prod = new Product();
                List<ParseObject> product = new List<ParseObject>();
                product.Add(s.Get<ParseObject>(Constants.PRODUCT));
                subCategory.products = (List<Product>)prod.convert(product);
            }
            return subCategories;
            throw new NotImplementedException();
        }
    }
}