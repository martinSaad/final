using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class Business : Convertor
    {
        public string objectId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string website { get; set; }
        public string facebookPage { get; set; }
        public string phoneNumber { get; set; }
        public User user { get; set; }
        public string logo { get; set; } //link to photo
        public List<Product> products { get; set; }

        public Business()
        {
            products = new List<Product>();
        }

        public IEnumerable<Object> convert(IEnumerable<ParseObject> objects)
        {
            List<Business> businesses = new List<Business>();
            foreach (ParseObject b in objects)
            {
                Business business = new Business();
                business.objectId = b.ObjectId;
                business.name = b.Get<string>(Constants.NAME);
                business.address = b.Get<string>(Constants.ADRESS);
                business.website = b.Get<string>(Constants.WEBSITE);
                business.facebookPage = b.Get<string>(Constants.FACEBOOK_PAGE);
                business.phoneNumber = b.Get<string>(Constants.PHONE_NUMBER);
                business.logo = b.Get<string>(Constants.LOGO);
                business.user = b.Get<User>(Constants.USER);


                Product prod = new Product();
                List<ParseObject> product = new List<ParseObject>();
                product.Add(b.Get<ParseObject>(Constants.PRODUCTS));
                business.products = (List<Product>)(prod.convert(product));

                businesses.Add(business);
            }
            return businesses;
            throw new NotImplementedException();
        }
    }
}