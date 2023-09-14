using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistencia.Data;
namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly PracticasTokenContext _context;

    public UserRepository(PracticasTokenContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
    }
}