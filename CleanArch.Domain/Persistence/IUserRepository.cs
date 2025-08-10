using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task Add(User user);
}