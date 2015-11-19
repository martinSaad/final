using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Business
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
    }
}