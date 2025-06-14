using DesignPatternsDemoApi.Interfaces;
using DesignPatternsDemoApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DesignPatternsDemoApi.Services;

public class CachedUserService : IUserService
{
    private readonly IUserService _inner;
    private readonly IMemoryCache _cache;

    public CachedUserService(IUserService inner, IMemoryCache cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _cache.GetOrCreate("users", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return _inner.GetAllUsers();
        });
    }

    public User GetUserById(int id) => _inner.GetUserById(id);

    public void AddUser(User user)
    {
        _inner.AddUser(user);
        _cache.Remove("users"); // Invalidate cache
    }
}
