using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
