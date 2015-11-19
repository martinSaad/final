using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class Manufacturer : Convertor
    {
        public string objectId { get; set; }
        public string name { get; set; }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach (ParseObject m in objects)
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.objectId = m.ObjectId;
                manufacturer.name = m.Get<string>(Constants.NAME);

                manufacturers.Add(manufacturer);
            }
            return manufacturers;
            throw new NotImplementedException();
        }
    }
}