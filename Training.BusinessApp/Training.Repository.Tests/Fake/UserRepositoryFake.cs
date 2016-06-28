using System.Collections.Generic;
using System.Linq;
using Training.DataAccess;
using Training.Repository;

namespace Training.Service.Tests.Dummy
{
    public class UserRepositoryFake : IUserRepository
    {
        public IList<User> Users { get; set; }

        public UserRepositoryFake()
        {
            Users=new List<User>();
        }

        public User GetById(int id)
        {
            return Users.First(x => x.Id == id);
        }

        public User Add(User user)
        {
            Users.Add(user);
            return user;
        }
    }
}