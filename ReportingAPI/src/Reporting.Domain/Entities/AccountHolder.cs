using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class AccountHolder
{
    public int AccountHolderId { get; set; }

    public string AccountHolderName { get; set; } = null!;

    public string AccountHolderType { get; set; } = null!;

    public decimal WithholdingPercentage { get; set; }

    public int InvestorId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Investor Investor { get; set; } = null!;
}
