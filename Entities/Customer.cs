using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : User
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
    }
}
