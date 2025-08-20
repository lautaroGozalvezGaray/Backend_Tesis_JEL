using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api_OsteoHealth_Tesis.Models;


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

        private static readonly string ConexionSql = Environment.GetEnvironmentVariable("ConexionSQL");
            


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
            var connectionString = Environment.GetEnvironmentVariable("ConexionSQL");

            services.AddDbContext<OsteoHealthContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddApiVersioning(o => o.ReportApiVersions = true);
            services.AddCors();

            services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


            //services.AddScoped<IPacienteBL, PacienteBL>();
            //services.AddScoped<ILoginBL, LoginBL>();

            RegisterServices(services);


            services.AddAuthorizationBuilder();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0", new OpenApiInfo { Title = "Api OsteoHealth", Version = "1.0" });

                // ?? Esquema ID estable: nombre completo y sin '+'
                c.CustomSchemaIds(t => (t.FullName ?? t.Name).Replace("+", "."));

                // Solo incluir XML si existe
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

                // JWT como ya tenías
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT como: Bearer {token}"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() }
                });
            });





            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer           = true,
                       ValidateAudience         = true,
                       ValidateLifetime         = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer              = Configuration["Jwt:Issuer"],
                       ValidAudience            = Configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? string.Empty))
                   };
               });

            services.AddControllers();





        }



        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Confirmar conexión a la base de datos
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<OsteoHealthContext>();
                    try
                    {
                        db.Database.GetDbConnection().Open();
                        Console.WriteLine("? Conexión a la base de datos establecida correctamente.");
                    }
                    catch (Exception innerEx)
                    {
                        Console.WriteLine("? Error al intentar conectar con la base de datos:");
                        Console.WriteLine($"   ?? Mensaje: {innerEx.Message}");

                        if (innerEx.InnerException != null)
                        {
                            Console.WriteLine($"   ?? InnerException: {innerEx.InnerException.Message}");
                        }

                        Console.WriteLine($"   ?? StackTrace: {innerEx.StackTrace}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error general: {ex.Message}");
            }



            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(b => b.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Swagger Api Gerenciamiento de Viajes");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Obtiene el ensamblado actual
            var assembly = Assembly.GetExecutingAssembly();

            // Filtra todas las clases públicas que implementan una interfaz
            var typesWithInterfaces = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract)
                .Select(type => new
                {
                    Implementation = type,
                    Interface = type.GetInterface("I" + type.Name) // Busca una interfaz con el prefijo "I"
                })
                .Where(t => t.Interface != null);

            // Registra cada tipo encontrado como Scoped
            foreach (var type in typesWithInterfaces)
            {
                services.AddScoped(type.Interface, type.Implementation);
            }
        }
    }
}
