using Application.Repository;
using Domain.Interfaces;
using Persistence;
using Persistencia.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PracticasTokenContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    public UnitOfWork(PracticasTokenContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}