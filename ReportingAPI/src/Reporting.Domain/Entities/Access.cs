using System;
using System.Collections.Generic;

namespace Reporting.Domain.Entities;

public partial class Access
{
    public int AccessId { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? PasswordHash { get; set; }
}
