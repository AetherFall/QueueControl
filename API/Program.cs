using Infrastructure.Configuration;
using Infrastructure.Context;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "QueueControl API",
        Description = "API de gestion des imprimantes, documents, types d'impression, mais aussi des files d'attente d'impression afin de contrôler les impressions.",
        Contact = new OpenApiContact
        {
            Name = "Joingnez-nous via discord",
            Url = new Uri("https://discord.gg/AtPHq9zE")
        },
        License = new OpenApiLicense
        {
            Name = "Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International",
            Url = new Uri("https://github.com/AetherFall/QueueControl/blob/main/LICENSE.md")
        }
    })
);

builder.Services.Scan(scan => scan
    .FromApplicationDependencies(app => app.FullName.StartsWith("Application") || app.FullName.StartsWith("Infrastructure"))
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
    .AsImplementedInterfaces()
    .WithTransientLifetime()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithTransientLifetime());

// Configurer la base de données
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();
    DatabaseSeeder.Seed(scope.ServiceProvider);
}


// Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "QueueControl API v1");
        options.InjectStylesheet("/swagger-ui/custom.css");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
