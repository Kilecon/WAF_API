namespace WAF_API_Presentation
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;
    using MongoDB.Driver;
    using WAF_API_Application.Services;
    using WAF_API_Domain.Comment.Dtos;
    using WAF_API_Domain.Comment.Factory;
    using WAF_API_Domain.Note.Dtos;
    using WAF_API_Domain.Note.Factory;
    using WAF_API_Infrastructure.DbSettings;
    using WAF_API_Infrastructure.Repositories;
    using System;
    using System.IO;
    using WAF_API_Application.Services.NoteService;
    using WAF_API_Application.Services.CommentService;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a web application builder
            var builder = WebApplication.CreateBuilder(args);

            // Register MongoDB serializer for Guid (CSharpLegacy)
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configure DbSettings from appsettings.json
            builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

            // Register MongoDB context as a singleton service
            builder.Services.AddSingleton<IMongoDatabase>(sp =>
            {
                var dbSettings = sp.GetRequiredService<IOptions<DbSettings>>().Value;
                var client = new MongoClient(dbSettings.ConnectionString);
                return client.GetDatabase(dbSettings.DbName);
            });

            // Register repositories and services (scoped for request lifetime)
            builder.Services.AddScoped<IBaseRepository<ChallengeDto>, NoteRepository>();
            builder.Services.AddScoped<IBaseRepository<ChallengeDto>, NoteRepository>();
            builder.Services.AddScoped<IChallengeRepository, NoteRepository>();
            builder.Services.AddScoped<IChallengeService, ChallengeService>();
            builder.Services.AddScoped<IChallengeFactory, ChallengeFactory>();

            builder.Services.AddScoped<IBaseRepository<CommentDto>, CommentRepository>();
            builder.Services.AddScoped<IBaseRepository<CommentDto>, CommentRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentFactory, CommentFactory>();

            // Register controllers for API
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; });

            // Add Swagger documentation support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Include XML comments from the documentation file (ensure this path is correct)
                var xmlFile = Path.Combine(AppContext.BaseDirectory, "WAF_API_Présentation.xml");
                if (File.Exists(xmlFile))
                {
                    c.IncludeXmlComments(xmlFile);
                }
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes API", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger(); // Enable Swagger JSON
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes API v1");
                    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root of the application
                });

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map controllers to the HTTP pipeline
            app.MapControllers();

            // Start the application
            app.Run();
        }
    }
}
