using HumanResource.Core.Models;
using System.Collections.Generic;

namespace HumanResource.Core.Services.Interfaces
{
    public interface IUserService 
    {
        public List<UserResponseModel> GetUserByName(string name);

        public UserResponseModel SaveUser(UserRequestModel userRequestModel);
    }
}
