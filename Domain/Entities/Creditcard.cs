namespace Domain.Entities;

public partial class Creditcard
{
    public int CreditcardId { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardtype { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
