using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class GroupBuying : Convertor
    {
        public string objectId { get; set; }
        public List<Bid> bids { get; set; }
        public User groupManager { get; set; }
        public List<User> users { get; set; }

        public Product product { get; set; }
        public DateTime groupCreated { get; set; }
        public DateTime expirationDate { get; set; }
        

        public GroupBuying()
        {
            //groupCreated = new DateTime();
            users = new List<User>();
            bids = new List<Bid>();
        }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<GroupBuying> groups = new List<GroupBuying>();
            foreach (ParseObject g in objects)
            {
                GroupBuying group = new GroupBuying();
                group.objectId = g.ObjectId;
                group.expirationDate = g.Get<DateTime>(Constants.EXPIRATION_DATE);

                User user = new User();
                List<ParseObject> users = new List<ParseObject>();
                users.Add(g.Get<ParseObject>(Constants.USERS));
                group.users = (List<User>)user.convert(users);

                //for group manager
                users = null;
                users.Add(g.Get<ParseObject>(Constants.GROUP_MANAGER));
                group.groupManager = (User)user.convert(users);

                Product prod = new Product();
                List<ParseObject> product = new List<ParseObject>();
                product.Add(g.Get<ParseObject>(Constants.PRODUCT));
                group.product = (Product)prod.convert(product);

                Bid b = new Bid();
                List<ParseObject> bid = new List<ParseObject>();
                bid.Add(g.Get<ParseObject>(Constants.BIDS));
                group.bids = (List<Bid>)b.convert(bid);

                groups.Add(group);
            }
            return groups;
            throw new NotImplementedException();
        }
    }



}