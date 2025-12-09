using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bakeryShop.Models;

public partial class BakeryShopContext : DbContext
{
    public BakeryShopContext()
    {
    }

    public BakeryShopContext(DbContextOptions<BakeryShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bakeryShop;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pk");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Roleid).HasColumnName("roleid");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("employees_roles_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_pk");

            entity.ToTable("sales");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Totalprice).HasColumnName("totalprice");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("sales_employees_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("sales_products_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
