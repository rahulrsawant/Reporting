namespace Reporting.Application.Clients;

public interface IClientService
{
    Task<List<ClientDto>> GetAllAsync();

    Task<ClientDto?> GetByIdAsync(int clientId);
}