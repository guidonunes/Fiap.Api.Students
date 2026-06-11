using Fiap.Api.Students.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Students.Data;

public class DatabaseContext: DbContext
{
    public virtual DbSet<RepresentativeModel> Representatives { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RepresentativeModel>(entity =>
        {
            entity.ToTable("API_REPRESENTATIVES");
            entity.HasKey(e => e.RepresentativeId);
            entity.Property(e => e.RepresentativeName).IsRequired();
            entity.HasIndex(e => e.Cpf).IsUnique();
        });
    }
    
    public DatabaseContext(DbContextOptions options) : base(options) { }
    
    protected DatabaseContext() { }
}