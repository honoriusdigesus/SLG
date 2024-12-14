namespace Domain.Entities;
public partial class Zone
{
    public int ZoneId { get; set; }

    public string? Zonename { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
