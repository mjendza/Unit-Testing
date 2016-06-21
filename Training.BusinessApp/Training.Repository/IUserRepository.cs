using Training.DataAccess;

namespace Training.Repository
{
    public interface IUserRepository
    {
        User GetById(int id);
        User Add(User user);
    }
}