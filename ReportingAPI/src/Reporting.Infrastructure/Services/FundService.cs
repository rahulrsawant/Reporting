using Microsoft.EntityFrameworkCore;
using Reporting.Application.Funds;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Infrastructure.Services;

public class FundService : IFundService
{
    private readonly ReportingDbContext _db;

    public FundService(ReportingDbContext db)
    {
        _db = db;
    }

    public async Task<List<FundDto>> GetAllAsync()
    {
        return await _db.Funds
            .AsNoTracking()
            .Select(f => new FundDto(f.FundId, f.FundCode, f.FundName, f.FundDomicile, f.FundCurrency, f.ClientId, f.CreateDate))
            .ToListAsync();
    }

    public async Task<FundDto?> GetByIdAsync(int fundId)
    {
        return await _db.Funds
            .AsNoTracking()
            .Where(f => f.FundId == fundId)
            .Select(f => new FundDto(f.FundId, f.FundCode, f.FundName, f.FundDomicile, f.FundCurrency, f.ClientId, f.CreateDate))
            .FirstOrDefaultAsync();
    }
}
