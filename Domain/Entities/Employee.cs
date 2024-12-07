using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Document { get; set; } = null!;

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Phone { get; set; }

    public int? ZoneId { get; set; }

    public virtual ICollection<Advance> AdvanceBeneficiaries { get; set; } = new List<Advance>();

    public virtual ICollection<Advance> AdvanceResponsibles { get; set; } = new List<Advance>();

    public virtual ICollection<Costcenter> Costcenters { get; set; } = new List<Costcenter>();

    public virtual Creditcard? Creditcard { get; set; }

    public virtual Zone? Zone { get; set; }
}
