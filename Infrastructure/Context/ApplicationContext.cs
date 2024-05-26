using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Infrastructure.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Printer> Printers { get; set; } = null!;
    public DbSet<PrintType> PrintTypes { get; set; } = null!;
    public DbSet<PrintDocument> PrintDocuments { get; set; } = null!;
    public DbSet<PrintQueue> PrintQueues { get; set; } = null!;

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