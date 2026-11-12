namespace Reporting.Application.Funds;

public interface IFundService
{
    Task<List<FundDto>> GetAllAsync();

    Task<FundDto?> GetByIdAsync(int fundId);
}
