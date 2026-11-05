using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class AccountBalance
{
    public int AccountBalanceId { get; set; }

    public decimal Balance { get; set; }

    public string AccountBalanceCurrency { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int InvestorId { get; set; }

    public virtual Investor Investor { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
