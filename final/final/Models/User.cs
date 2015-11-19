using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class User : Convertor
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

        public IEnumerable<Object> convert(IEnumerable<ParseObject> objects)
        {
            List<User> users = new List<User>();
            foreach (ParseObject u in objects)
            {
                User user = new User();
                user.objectId = u.ObjectId;
                user.firstName = u.Get<string>(Constants.FIRST_NAME);
                user.lastName = u.Get<string>(Constants.LAST_NAME);
                user.email = u.Get<string>(Constants.EMAIL);
                user.firstName = u.Get<string>(Constants.FIRST_NAME);
                user.isClient = u.Get<bool>(Constants.IS_CLIENT);
                user.isBusiness = u.Get<bool>(Constants.IS_BUSINESS);
                if (user.isBusiness)
                {
                    //extract business from Parse
                    Business bus = new Business();
                    List <ParseObject> business = new List<ParseObject>();
                    business.Add(u.Get<ParseObject>(Constants.BUSINESS));
                    user.business = (Business)bus.convert(business); 
                }

                GroupBuying group = new GroupBuying();
                List<ParseObject> groups = new List<ParseObject>();
                groups.Add(u.Get<ParseObject>(Constants.GROUPS));
                user.groups = (List<GroupBuying>)group.convert(groups);

                users.Add(user);
            }
            return users;
            throw new NotImplementedException();
        }

        public static explicit operator User(IEnumerable<object> v)
        {
            throw new NotImplementedException();
        }
    }


}