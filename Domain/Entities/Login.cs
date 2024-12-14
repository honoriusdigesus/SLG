namespace Domain.Entities;

public partial class Login
{
    public int TokenId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Revoked { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
