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
            List<ProductCategory> productCategories = new List<ProductCategory>();
            foreach (ParseObject p in objects)
            {
                ProductCategory productCategorie = new ProductCategory();
                productCategorie.objectId = p.ObjectId;
                productCategorie.name = p.Get<string>(Constants.NAME);

                SubCategory sub = new SubCategory();
                List<ParseObject> subCategory = new List<ParseObject>();
                subCategory.Add(p.Get<ParseObject>(Constants.SUB_CATEGORY));
                productCategorie.subCategory= (List<SubCategory>)sub.convert(subCategory);
            }
            return productCategories;
            throw new NotImplementedException();
        }
    }
}