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
using WAF_API_Domain.Difficulty.Dtos;
using WAF_API_Domain.Difficulty.Factory;
using WAF_API_Domain.Truth.Dtos;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.WouldYouRather.Dtos;
using WAF_API_Domain.NeverHaveIEver.Dtos;
using WAF_API_Application.Services.DifficultyService;
using WAF_API_Application.Services.NotationService;
using WAF_API_Application.Services.SuggestionService;
using WAF_API_Domain.Notation.Dtos;
using WAF_API_Domain.Notation.Factory;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Domain.Suggestion.Factory;

namespace WAF_API_Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

            builder.Services.AddSingleton<IMongoDatabase>(sp =>
            {
                var dbSettings = sp.GetRequiredService<IOptions<DbSettings>>().Value;
                var client = new MongoClient(dbSettings.ConnectionString);
                return client.GetDatabase(dbSettings.DbName);
            });

            builder.Services.AddScoped<IBaseRepository<DareDto>, DareRepository>();
            builder.Services.AddScoped<IDareRepository, DareRepository>();
            builder.Services.AddScoped<IDareService, DareService>();
            builder.Services.AddScoped<IDareFactory, DareFactory>();

            builder.Services.AddScoped<IBaseRepository<TruthDto>, TruthRepository>();
            builder.Services.AddScoped<ITruthFactory, TruthFactory>();
            builder.Services.AddScoped<ITruthService, TruthService>();
            builder.Services.AddScoped<ITruthRepository, TruthRepository>();

            builder.Services.AddScoped<IBaseRepository<ParanoiaDto>, ParanoiaRepository>();
            builder.Services.AddScoped<IParanoiaFactory, ParanoiaFactory>();
            builder.Services.AddScoped<IParanoiaService, ParanoiaService>();
            builder.Services.AddScoped<IParanoiaRepository, ParanoiaRepository>();

            builder.Services.AddScoped<IBaseRepository<WouldYouRatherDto>, WouldYouRatherRepository>();
            builder.Services.AddScoped<IWouldYouRatherFactory, WouldYouRatherFactory>();
            builder.Services.AddScoped<IWouldYouRatherService, WouldYouRatherService>();
            builder.Services.AddScoped<IWouldYouRatherRepository, WouldYouRatherRepository>();

            builder.Services.AddScoped<IBaseRepository<NeverHaveIEverDto>, NeverHaveIEverRepository>();
            builder.Services.AddScoped<INeverHaveIEverFactory, NeverHaveIEverFactory>();
            builder.Services.AddScoped<INeverHaveIEverService, NeverHaveIEverService>();
            builder.Services.AddScoped<INeverHaveIEverRepository, NeverHaveIEverRepository>();

            builder.Services.AddScoped<INotationRepository<NotationDto>, NotationRepository>();
            builder.Services.AddScoped<INotationFactory, NotationFactory>();
            builder.Services.AddScoped<INotationRepository<NotationDto>, NotationRepository>();
            builder.Services.AddScoped<INotationService, NotationService>();

            builder.Services.AddScoped<IBaseRepository<DifficultyDto>, DifficultyRepository>();
            builder.Services.AddScoped<IDifficultyFactory, DifficultyFactory>();
            builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
            builder.Services.AddScoped<IDifficultyFactory, DifficultyFactory>();
            
            builder.Services.AddScoped<IBaseRepository<SuggestionDto>, SuggestionRepository>();
            builder.Services.AddScoped<ISuggestionFactory, SuggestionFactory>();
            builder.Services.AddScoped<ISuggestionRepository<SuggestionDto>, SuggestionRepository>();
            builder.Services.AddScoped<ISuggestionService, SuggestionService>();
            
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = Path.Combine(AppContext.BaseDirectory, "WAF_API_Presentation.xml");
                if (File.Exists(xmlFile))
                {
                    c.IncludeXmlComments(xmlFile);
                }

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes API", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            // Ensure `WatchForChanges` is executed properly after building the app
            var rankingRepository = app.Services.GetRequiredService<INotationRepository<NotationDto>>();
            rankingRepository.WatchForChanges();

            app.Run();

        }
    }
}
