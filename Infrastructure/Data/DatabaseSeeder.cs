using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;

namespace Infrastructure.Data;

public static class DatabaseSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>());

        // Vérifier si la base de données est déjà initialisée
        if (context.Printers.Any())
            return;

        // Ajouter des types d'impression
        var printTypeEPL = new PrintType { Id = 1, Name = "EPL" };
        var printTypeZPL = new PrintType { Id = 2, Name = "ZPL" };
        var printTypePDF = new PrintType { Id = 3, Name = "PDF" };
        var printTypeCPDF = new PrintType { Id = 4, Name = "CPDF" };

        context.PrintTypes.AddRange(printTypeEPL, printTypeZPL, printTypePDF, printTypeCPDF);
        
        context.SaveChanges();
    }
}