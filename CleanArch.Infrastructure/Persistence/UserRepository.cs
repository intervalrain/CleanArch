using CleanArch.Domain.Entities;
using CleanArch.Domain.Persistence;

namespace CleanArch.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public Task Add(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetUserByEmail(string email)
    {
        var user = _users.SingleOrDefault(u => u.Email == email);
        return Task.FromResult(user);
    }
}