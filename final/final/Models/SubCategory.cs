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

            foreach (ParseObject subCategory in objects)
            {
                SubCategory subcategory = new SubCategory();
                subcategory.objectId = subCategory.ObjectId;
                subcategory.name = subCategory.Get<String>(Constants.NAME);
                subCategories.Add(subcategory);
            }
            return subCategories;
            throw new NotImplementedException();
        }
    }
}