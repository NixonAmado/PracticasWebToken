using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistencia.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly PracticasTokenContext _context;

    public RolRepository(PracticasTokenContext context) : base(context)
    {
       _context = context;
    }
}