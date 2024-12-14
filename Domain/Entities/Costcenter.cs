namespace Domain.Entities;

public partial class Costcenter
{
    public int CostcenterId { get; set; }

    public int? Costcenternumber { get; set; }

    public string? Description { get; set; }

    public int? ProjectmanagerId { get; set; }

    public virtual ICollection<Advance> Advances { get; set; } = new List<Advance>();

    public virtual Employee? Projectmanager { get; set; }
}
