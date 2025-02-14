using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiniApiTemplate.Config;
using MiniApiTemplate.Services;

// 📌 Création de l'application Web API
var builder = WebApplication.CreateBuilder(args);

// * ----------------------------------------------------------------------------------
// * 🔹 1. Configuration des services de l'application (D.I. - Dependency Injection)   |
//  * ---------------------------------------------------------------------------------

// ? ✅ Ajout du support pour les contrôleurs API
builder.Services.AddControllers();

// ? ✅ Injection de dépendances : Services métier et accès BDD
builder.Services.AddScoped<ExampleService>();   // Service métier (simule des données)
builder.Services.AddScoped<DatabaseService>();  // Service pour gérer SQLite

// ? ✅ Configuration des CORS pour gérer les requêtes cross-origin (voir CorsConfig.cs)
builder.Services.ConfigureCors();

// ? ✅ Configuration de Swagger (Documentation API interactive)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mini API Template",
        Version = "v1",
        Description = "Un template d'API minimaliste en ASP.NET Core avec SQLite.",
        Contact = new OpenApiContact
        {
            Name = "Ton Nom", // ? ✏️ Remplace par ton nom ou celui du projet
            Email = "contact@example.com", // ? ✏️ Remplace par un email de contact
            Url = new Uri("https://github.com/ton-projet"), // ? ✏️ Remplace par l'URL de ton projet
        }
    });
});

// ? ✅ Construction de l'application
var app = builder.Build();

// * -----------------------------------------------------------------------
// * 🔹 2. Configuration du pipeline middleware (Gestion des requêtes HTTP) |
// * -----------------------------------------------------------------------

// ? 🛠 Activer Swagger uniquement en mode développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { }); // Génération de la documentation API
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mini API Template v1");
        options.RoutePrefix = ""; // ? Swagger accessible directement à `http://localhost:5000`
    });
}

// ? 🔒 Middleware pour activer CORS (Cross-Origin Resource Sharing)
app.UseCors("AllowAll");

// ? 🔄 Middleware pour gérer le routage des requêtes HTTP
app.UseRouting();

// ? 🔑 Middleware d'autorisation (peut être utile si on ajoute de l'authentification)
app.UseAuthorization();

// ? 🎯 Ajout des routes des contrôleurs API
app.MapControllers();

// ? 🚀 Lancer l'application et écouter les requêtes HTTP
app.Run();