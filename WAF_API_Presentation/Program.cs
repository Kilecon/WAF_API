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
using WAF_API_Infrastructure.DbSettings;
using WAF_API_Infrastructure.Repositories;
using System;
using System.IO;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Application.Services.DareService;
using WAF_API_Application.Services.NeverHaveIEverService;
using WAF_API_Application.Services.ParanoiaService;
using WAF_API_Application.Services.TruthService;
using WAF_API_Application.Services.WouldYouRatherService;
using WAF_API_Domain.Dare.Factory;
using WAF_API_Domain.NeverHaveIEver.Factory;
using WAF_API_Domain.Paranoia.Factory;
using WAF_API_Domain.Truth.Factory;
using WAF_API_Domain.WouldYouRather.Factory;

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
    using WAF_API_Infrastructure.DbSettings;
    using WAF_API_Infrastructure.Repositories;
    using System;
    using System.IO;
    using WAF_API_Domain.Dare.Dtos;
    using WAF_API_Application.Services.DareService;
    using WAF_API_Domain.Dare.Factory;
    using WAF_API_Application.Services.Ranking;
    using WAF_API_Domain.Ranking.Models;
    using WAF_API_Domain.Ranking.Factory;
    using MongoDB.Bson.Serialization.IdGenerators;

    namespace WAF_API_Presentation

    {
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
                builder.Services.AddScoped<IBaseRepository<DareDto>, DareRepository>();
                builder.Services.AddScoped<IBaseRepository<DareDto>, DareRepository>();
                builder.Services.AddScoped<IDareRepository, DareRepository>();
                builder.Services.AddScoped<IDareService, DareService>();
                builder.Services.AddScoped<IDareFactory, DareFactory>();
                builder.Services.AddScoped<INeverHaveIEverRepository, NeverHaveIEverRepository>();
                builder.Services.AddScoped<INeverHaveIEverService, NeverHaveIEverService>();
                builder.Services.AddScoped<INeverHaveIEverFactory, NeverHaveIEverFactory>();
                builder.Services.AddScoped<ITruthFactory, TruthFactory>();
                builder.Services.AddScoped<ITruthService, TruthService>();
                builder.Services.AddScoped<ITruthRepository, TruthRepository>();
                builder.Services.AddScoped<IParanoiaFactory, ParanoiaFactory>();
                builder.Services.AddScoped<IParanoiaService, ParanoiaService>();
                builder.Services.AddScoped<IParanoiaRepository, ParanoiaRepository>();
                builder.Services.AddScoped<IWouldYouRatherFactory, WouldYouRatherFactory>();
                builder.Services.AddScoped<IWouldYouRatherService, WouldYouRatherService>();
                builder.Services.AddScoped<IWouldYouRatherRepository, WouldYouRatherRepository>();

                builder.Services.AddScoped<IRankingRepository<RankingDto>, RankingRepository>();
                builder.Services.AddScoped<IRankingFactory, RankingFactory>();
                builder.Services.AddScoped<IRankingRepository<RankingDto>, RankingRepository>();
                builder.Services.AddScoped<IRankingService, RankingService>();


                // Register controllers for API
                builder.Services.AddControllers()
                    .ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; });

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
}
