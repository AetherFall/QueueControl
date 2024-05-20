using Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enregistrer les services de l'application, de domaine et d'infrastructure
/*builder.Services.AddTransient<ICommandeService, CommandeService>();
builder.Services.AddTransient<IEmailService, EmailService>();*/

// Configurer la base de données
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

// Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
