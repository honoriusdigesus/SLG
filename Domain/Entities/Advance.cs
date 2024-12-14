namespace Domain.Entities;

public partial class Advance
{
    public int AdvanceId { get; set; }

    public decimal? Value { get; set; }

    public DateOnly Date { get; set; }

    public string? Status { get; set; }

    public int? ResponsibleId { get; set; }

    public int? BeneficiaryId { get; set; }

    public int? CostcenterId { get; set; }

    public byte[]? SupportFile { get; set; }

    public decimal? PendingLegalization { get; set; }

    public bool? Legalized { get; set; }

    public decimal? TotalExpenses { get; set; }

    public string? Comment { get; set; }

    public virtual Employee? Beneficiary { get; set; }

    public virtual Costcenter? Costcenter { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual Employee? Responsible { get; set; }
}
