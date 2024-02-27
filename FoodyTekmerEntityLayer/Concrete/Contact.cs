using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerEntityLayer.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime dateTime { get; set; }
    }
}
