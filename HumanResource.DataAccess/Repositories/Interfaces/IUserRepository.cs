using HumanResource.DataAccess.Entities;
using System.Collections.Generic;

namespace HumanResource.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetByName(string name);

        void Save(User user);
    }
}
