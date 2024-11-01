﻿using Api_OsteoHealth_Tesis.code;
using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api_OsteoHealth_Tesis
{
    /// <summary>
    /// Metodo de carga de configuracion
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// inicio configuracion
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static readonly string conexionSQL = Environment.GetEnvironmentVariable("ConexionSQL");


        /// <summary>
        /// configuracion
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            // Configura ApplicationDbContext usando la cadena de conexión en appsettings.json
            services.AddDbContextFactory<DbOsteoHealthContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(conexionSQL),
            sqlOptions => sqlOptions.CommandTimeout(3000))); // Timeout en segundos

            services.AddApiVersioning(o => o.ReportApiVersions = true);
            services.AddCors();

            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddScoped<IPacienteBL, PacienteBL>();



            services.AddAuthorizationBuilder();

            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("1.0", new OpenApiInfo
                {
                    Title = "Api OsteoHealth",
                    Version = "1.0"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


            });

        }



        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseCors(b => b.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseSwagger();

            // Serves the Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Swagger Api Gerenciamiento de Viajes");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
