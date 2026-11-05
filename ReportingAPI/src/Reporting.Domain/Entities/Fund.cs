using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class Fund
{
    public int FundId { get; set; }

    public string FundCode { get; set; } = null!;

    public string FundName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? FundDomicile { get; set; }

    public string? FundCurrency { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Investor> Investors { get; set; } = new List<Investor>();
}
