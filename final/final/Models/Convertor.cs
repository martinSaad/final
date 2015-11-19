using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace final.Models
{
    interface Convertor
    {
        IEnumerable<Object> convert(IEnumerable<ParseObject> objects);
    }
}
