using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Creditcard
{
    public int CreditcardId { get; set; }

    public string? Cardnumber { get; set; }

    public DateOnly? Expirydate { get; set; }

    public string? Cvv { get; set; }

    public string? Cardholdername { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
