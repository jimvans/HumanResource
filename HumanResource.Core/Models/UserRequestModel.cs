using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Core.Models
{
    public class UserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
