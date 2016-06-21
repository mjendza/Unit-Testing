namespace Training.Service
{
    public interface IUserService
    {
        UserDTO GetById(int id);
        UserDTO Save(UserDTO user);
    }
}