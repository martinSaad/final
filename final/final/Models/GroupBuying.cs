using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class GroupBuying
    {
        public string objectId { get; set; }
        public Bid bid { get; set; }
        public User groupManager { get; set; }
        public List<Product> products { get; set; }
        public DateTime groupCreated { get; set; }
        public DateTime expirationDate { get; set; }
        

        public GroupBuying()
        {
            //groupCreated = new DateTime();
            products = new List<Product>();
        }
    }



}