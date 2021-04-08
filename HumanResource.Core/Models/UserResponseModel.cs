using HumanResource.DataAccess.Entities;
using System.Collections.Generic;

namespace HumanResource.Core.Models
{
    public class UserResponseModel
    {
        public UserResponseModel()
        {
            ErrorMessage = new List<string>();
        }

        public User User { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
