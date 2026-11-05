using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class Investor
{
    public int InvestorId { get; set; }

    public string InvestorExternalId { get; set; } = null!;

    public string InvestorName { get; set; } = null!;

    public string? InvestorDomicile { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int FundId { get; set; }

    public virtual ICollection<AccountBalance> AccountBalances { get; set; } = new List<AccountBalance>();

    public virtual ICollection<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();

    public virtual Fund Fund { get; set; } = null!;
}
