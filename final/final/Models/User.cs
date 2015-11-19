using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class User
    {
        public string objectId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isBusiness { get; set; }
        public bool isClient { get; set; }
        public Business business { get; set; }
        public List<GroupBuying> groups { get; set; }

        public User()
        {
            groups = new List<GroupBuying>();
        }
    }


}