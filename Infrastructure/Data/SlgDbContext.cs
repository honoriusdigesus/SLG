using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class SlgDbContext : DbContext
{
    public SlgDbContext()
    {
    }

    public SlgDbContext(DbContextOptions<SlgDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advance> Advances { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Costcenter> Costcenters { get; set; }

    public virtual DbSet<Creditcard> Creditcards { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advance>(entity =>
        {
            entity.HasKey(e => e.AdvanceId).HasName("advance_pkey");

            entity.ToTable("advance");

            entity.Property(e => e.AdvanceId).HasColumnName("advance_id");
            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CostcenterId).HasColumnName("costcenter_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Legalized)
                .HasDefaultValue(false)
                .HasColumnName("legalized");
            entity.Property(e => e.PendingLegalization)
                .HasPrecision(10, 2)
                .HasColumnName("pending_legalization");
            entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.SupportFile).HasColumnName("support_file");
            entity.Property(e => e.TotalExpenses)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("total_expenses");
            entity.Property(e => e.Value)
                .HasPrecision(10, 2)
                .HasColumnName("value");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.AdvanceBeneficiaries)
                .HasForeignKey(d => d.BeneficiaryId)
                .HasConstraintName("advance_beneficiary_id_fkey");

            entity.HasOne(d => d.Costcenter).WithMany(p => p.Advances)
                .HasForeignKey(d => d.CostcenterId)
                .HasConstraintName("advance_costcenter_id_fkey");

            entity.HasOne(d => d.Responsible).WithMany(p => p.AdvanceResponsibles)
                .HasForeignKey(d => d.ResponsibleId)
                .HasConstraintName("advance_responsible_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Costcenter>(entity =>
        {
            entity.HasKey(e => e.CostcenterId).HasName("costcenter_pkey");

            entity.ToTable("costcenter");

            entity.HasIndex(e => e.Costcenternumber, "costcenter_costcenternumber_key").IsUnique();

            entity.Property(e => e.CostcenterId).HasColumnName("costcenter_id");
            entity.Property(e => e.Costcenternumber).HasColumnName("costcenternumber");
            entity.Property(e => e.ProjectmanagerId).HasColumnName("projectmanager_id");

            entity.HasOne(d => d.Projectmanager).WithMany(p => p.Costcenters)
                .HasForeignKey(d => d.ProjectmanagerId)
                .HasConstraintName("costcenter_projectmanager_id_fkey");
        });

        modelBuilder.Entity<Creditcard>(entity =>
        {
            entity.HasKey(e => e.CreditcardId).HasName("creditcard_pkey");

            entity.ToTable("creditcard");

            entity.HasIndex(e => e.EmployeeId, "creditcard_employee_id_key").IsUnique();

            entity.Property(e => e.CreditcardId).HasColumnName("creditcard_id");
            entity.Property(e => e.Cardholdername)
                .HasMaxLength(100)
                .HasColumnName("cardholdername");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(20)
                .HasColumnName("cardnumber");
            entity.Property(e => e.Cvv)
                .HasMaxLength(4)
                .HasColumnName("cvv");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Expirydate).HasColumnName("expirydate");

            entity.HasOne(d => d.Employee).WithOne(p => p.Creditcard)
                .HasForeignKey<Creditcard>(d => d.EmployeeId)
                .HasConstraintName("creditcard_employee_id_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.HasIndex(e => e.Document, "employee_document_key").IsUnique();

            entity.HasIndex(e => e.Email, "employee_email_key").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Document)
                .HasMaxLength(50)
                .HasColumnName("document");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.ZoneId).HasColumnName("zone_id");

            entity.HasOne(d => d.Zone).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("employee_zone_id_fkey");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("expense_pkey");

            entity.ToTable("expense");

            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.AdvanceId).HasColumnName("advance_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Companyname)
                .HasMaxLength(255)
                .HasColumnName("companyname");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Legalized)
                .HasDefaultValue(false)
                .HasColumnName("legalized");
            entity.Property(e => e.Observations).HasColumnName("observations");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.SupportFile).HasColumnName("support_file");
            entity.Property(e => e.Value)
                .HasPrecision(10, 2)
                .HasColumnName("value");

            entity.HasOne(d => d.Advance).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.AdvanceId)
                .HasConstraintName("expense_advance_id_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("expense_category_id_fkey");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.HasKey(e => e.ZoneId).HasName("zone_pkey");

            entity.ToTable("zone");

            entity.Property(e => e.ZoneId).HasColumnName("zone_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Zonename)
                .HasMaxLength(100)
                .HasColumnName("zonename");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
