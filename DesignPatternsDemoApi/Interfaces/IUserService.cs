using DesignPatternsDemoApi.Models;

namespace DesignPatternsDemoApi.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    void AddUser(User user);
}
