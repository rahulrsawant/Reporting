namespace Reporting.Application.Clients;

public record ClientDto(
    int ClientId,
    string ClientCode,
    string ClientName,
    DateTime CreateDate
);