using DesignPatternsDemoApi.Models;

namespace DesignPatternsDemoApi.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    void AddUser(User user);
}
