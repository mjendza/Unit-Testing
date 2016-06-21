
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DataAccess;

namespace Training.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DbContext _context;
        protected IQueryable<User> Records { get; private set; }
        public UserRepository()
        {
            _context = new SQLDataBaseEFContext();
            Records = _context.Set<User>();
        }

        public User GetById(int id)
        {
            return Records.First(x => x.Id == id);
        }

        public User Add(User user)
        {
            _context.Set<User>().Add(user);

            _context.SaveChanges();
            return user;
        }
    }
}
