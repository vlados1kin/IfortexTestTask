using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUser()
    {
        return await _dbContext.Users.OrderByDescending(u => u.Orders.Count).FirstAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.Where(u => u.Status == UserStatus.Inactive).ToListAsync();
    }
}