using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class GroupBuying
    {
        public string objectId { get; set; }
        public List<Bid> bids { get; set; }
        public User groupManager { get; set; }
        public List<User> users { get; set; }

        public List<Product> product { get; set; }
        public DateTime groupCreated { get; set; }
        public DateTime expirationDate { get; set; }
        

        public GroupBuying()
        {
            //groupCreated = new DateTime();
            product = new List<Product>();
            users = new List<User>();
            bids = new List<Bid>();
        }
    }



}