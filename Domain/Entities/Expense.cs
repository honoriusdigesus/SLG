using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public decimal? Value { get; set; }

    public DateOnly Date { get; set; }

    public string? Status { get; set; }

    public int? CategoryId { get; set; }

    public string? Observations { get; set; }

    public byte[]? SupportFile { get; set; }

    public int? AdvanceId { get; set; }

    public bool? Legalized { get; set; }

    public string? Companyname { get; set; }

    public string? Comment { get; set; }

    public virtual Advance? Advance { get; set; }

    public virtual Category? Category { get; set; }
}
