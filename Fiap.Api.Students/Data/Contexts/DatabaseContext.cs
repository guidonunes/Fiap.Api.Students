using Fiap.Api.Students.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Students.Data;

public class DatabaseContext: DbContext
{
    public virtual DbSet<RepresentativeModel> Representatives { get; set; }
    public virtual DbSet<ClientModel> Clients { get; set; }
    public virtual DbSet<ProductModel> Products { get; set; }
    public virtual DbSet<StoreModel> Stores { get; set; }
    public virtual DbSet<OrderModel> Orders { get; set; }
    public virtual DbSet<SupplierModel> Suppliers { get; set; }
    public virtual DbSet<OrderProductModel> OrderProducts { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RepresentativeModel>(entity =>
        {
            entity.ToTable("API_REPRESENTATIVES");
            entity.HasKey(e => e.RepresentativeId);
            entity.Property(e => e.RepresentativeName).IsRequired();
            entity.HasIndex(e => e.Cpf).IsUnique();
        });

        modelBuilder.Entity<ClientModel>(entity =>
        {
            entity.ToTable("API_CLIENT");
            entity.HasKey(e => e.ClientId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Observation).HasMaxLength(500);
            
            entity.HasOne(e => e.Representative)
                .WithMany()
                .HasForeignKey(e => e.RepresentativeId)
                .IsRequired();
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.ToTable("API_PRODUCT");
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(e => e.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(e => e.SupplierId);
        });

        modelBuilder.Entity<StoreModel>(entity =>
        {
            entity.ToTable("API_STORE");
            entity.HasKey(e => e.StoreId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Address);
            
            entity.HasMany(e=>e.Orders)
                .WithOne(o=>o.Store)
                .HasForeignKey(o=>o.StoreId);
        });

        modelBuilder.Entity<OrderModel>(entity =>
        {
            entity.ToTable("API_ORDER");
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.OrderDate).HasColumnType("date");
            
            entity.HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId);
            
            entity.HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId);
        });

        modelBuilder.Entity<SupplierModel>(entity =>
        {
            entity.ToTable("API_SUPPLIER");
            entity.HasKey(e => e.SupplierId);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<OrderProductModel>(entity =>
        {
            entity.HasKey(op => new { op.OrderId, op.ProductId });
            
            entity.HasOne(op => op.Order)
                .WithMany(o=> o.OrderProducts)
                .HasForeignKey(op => op.OrderId);
        });
    }
    
    public DatabaseContext(DbContextOptions options) : base(options) { }
    
    protected DatabaseContext() { }
}