using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Printer?> Printers { get; set; }
    public DbSet<PrintType?> PrintTypes { get; set; }
    public DbSet<PrintDocument?> PrintDocuments { get; set; }
    public DbSet<PrintQueue?> PrintQueues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurations spécifiques des entités
        modelBuilder.Entity<Printer>()
            .HasOne(p => p.PrintType)
            .WithMany(pt => pt.Printers)
            .HasForeignKey(p => p.PrintTypeId);

        modelBuilder.Entity<PrintDocument>()
            .HasOne(pd => pd.PrintType)
            .WithMany(pt => pt.PrintDocuments)
            .HasForeignKey(pd => pd.PrintTypeId);

        modelBuilder.Entity<PrintQueue>()
            .HasOne(pq => pq.Document)
            .WithMany()
            .HasForeignKey(pq => pq.DocumentId);

        modelBuilder.Entity<PrintQueue>()
            .HasOne(pq => pq.Printer)
            .WithMany()
            .HasForeignKey(pq => pq.PrinterId);
    }
}