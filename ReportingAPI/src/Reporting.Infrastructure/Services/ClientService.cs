using Microsoft.EntityFrameworkCore;
using Reporting.Application.Clients;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Infrastructure.Services;

public class ClientService : IClientService
{
    private readonly ReportingDbContext _db;

    public ClientService(ReportingDbContext db)
    {
        _db = db;
    }

    public async Task<List<ClientDto>> GetAllAsync()
    {
        return await _db.Clients
            .AsNoTracking()
            .Select(c => new ClientDto(c.ClientId, c.ClientCode, c.ClientName, c.CreateDate))
            .ToListAsync();
    }

    public async Task<ClientDto?> GetByIdAsync(int clientId)
    {
        return await _db.Clients
            .AsNoTracking()
            .Where(c => c.ClientId == clientId)
            .Select(c => new ClientDto(c.ClientId, c.ClientCode, c.ClientName, c.CreateDate))
            .FirstOrDefaultAsync();
    }
}