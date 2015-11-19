using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.Collections;

namespace final.Models
{
    public class Product : Convertor
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

        public IEnumerable<Object> convert(IEnumerable<ParseObject> objects)
        {
            List<Product> products = new List<Product>(); 
            foreach (ParseObject p in objects)
            {
                Product product = new Product();
                product.objectId = p.ObjectId;
                product.title = p.Get<string>(Constants.TITLE);
                products.Add(product);
            }
            return products;
            throw new NotImplementedException();
        }
    }
}

