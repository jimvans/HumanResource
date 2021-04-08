using HumanResource.Core.Models;
using HumanResource.Core.Services.Interfaces;
using HumanResource.DataAccess;
using HumanResource.DataAccess.Entities;
using HumanResource.DataAccess.Repositories;
using HumanResource.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HumanResource.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IUserRepository _userRepository;

        private static readonly Regex MobilePhone = new Regex(@"(\d{1,2})?\-?\d{10}");

        public UserService(ApplicationContext context)
        {
            applicationContext = context;
            _userRepository = new UserRepository(applicationContext);
        }

        public List<UserResponseModel> GetUserByName(string name)
        {
            var response = new List<UserResponseModel>();
            
            var users = _userRepository.GetByName(name);
            if (users.Count > 0)
            {
                response.AddRange(users.Select(u => new UserResponseModel()
                {
                    User = u,
                    ErrorMessage = null
                }));
            }
            return response;
        }

        public UserResponseModel SaveUser(UserRequestModel userRequestModel)
        {
            var response = new UserResponseModel();
            if (!IsMobileNumberValid(userRequestModel.MobilePhone))
            {
                response.ErrorMessage.Add("Mobile Phone provided is invalid.");
            }

            if (!IsEmailValid(userRequestModel.Email))
            {
                response.ErrorMessage.Add("Email Address provided is invalid.");
            }

            if (response.ErrorMessage.Count == 0)
            {
                var user = new User()
                {
                    FirstName = userRequestModel.FirstName,
                    LastName = userRequestModel.LastName,
                    Address = userRequestModel.Address,
                    MobilePhone = userRequestModel.MobilePhone,
                    Email = userRequestModel.Email
                };
                response.User = user;
                _userRepository.Save(user);
            }

            return response;
        }

        private bool IsMobileNumberValid(string mobileNumber)
        {
            return MobilePhone.IsMatch(mobileNumber);
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
