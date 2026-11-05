using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientCode { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Fund> Funds { get; set; } = new List<Fund>();
}
