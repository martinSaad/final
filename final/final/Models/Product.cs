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
                //product.image = p.Get<string>(Constants.IMAGE);
                products.Add(product);

                /*
                Manufacturer manu = new Manufacturer();
                List<ParseObject> manufacturer = new List<ParseObject>();
                manufacturer.Add(p.Get<ParseObject>(Constants.MANUFACTURER_ID));
                product.manufacturer = (Manufacturer)manu.convert(manufacturer);
                products.Add(product);

                Business bus = new Business();
                List<ParseObject> business = new List<ParseObject>();
                business.Add(p.Get<ParseObject>(Constants.BUSINESS));
                product.businesses = (List<Business>)bus.convert(business);
                */
            }
            return products;
            throw new NotImplementedException();
        }
    }
}

