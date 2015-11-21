using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class ProductCategory : Convertor
    {
        public string objectId { get; set; }
        public string name { get; set; }
        public List<SubCategory> subCategory { get; set; }

        public ProductCategory()
        {
            subCategory = new List<SubCategory>();
        }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<ProductCategory> products = new List<ProductCategory>();

            foreach (ParseObject product in objects)
            {
                ProductCategory productcategory = new ProductCategory();
                productcategory.objectId = product.ObjectId;
                productcategory.name = product.Get<String>(Constants.NAME);
                products.Add(productcategory);
            }
            return products;
            throw new NotImplementedException();
        }
    }
}