using HumanResource.DataAccess.Entities;
using HumanResource.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResource.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext applicationContext;

        public UserRepository(ApplicationContext appContext)
        {
            applicationContext = appContext;
        }

        public List<User> GetByName(string name)
        {
            return applicationContext.Users.Where(
                b => b.FirstName.ToLower().Equals(name.ToLower()) || b.LastName.ToLower().Equals(name.ToLower())).ToList();
        }

        public void Save(User user)
        {
            applicationContext.Add(user);
            applicationContext.SaveChanges();
        }
    }
}
