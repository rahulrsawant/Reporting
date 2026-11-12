namespace Reporting.Application.Funds;

public record FundDto(
    int FundId,
    string FundCode,
    string FundName,
    string? FundDomicile,
    string? FundCurrency,
    int ClientId,
    DateTime CreateDate
);
