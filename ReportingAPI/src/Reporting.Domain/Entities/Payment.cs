using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentCurrency { get; set; } = null!;

    public int AccountBalanceId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual AccountBalance AccountBalance { get; set; } = null!;
}
