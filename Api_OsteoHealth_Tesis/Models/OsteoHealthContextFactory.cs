using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api_OsteoHealth_Tesis.Models
{
    // Usado por `dotnet ef` para crear el DbContext en tiempo de diseño.
    public class OsteoHealthContextFactory : IDesignTimeDbContextFactory<OsteoHealthContext>
    {
        public OsteoHealthContext CreateDbContext(string[] args)
        {
            // 1) Prioridad: variable de entorno
            var conn = Environment.GetEnvironmentVariable("ConexionSQL");

            // 2) Fallback: appsettings (ignora errores de parseo)
            if (string.IsNullOrWhiteSpace(conn))
            {
                try
                {
                    var basePath = Directory.GetCurrentDirectory();
                    var cfg = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
                        .AddEnvironmentVariables()
                        .Build();

                    conn = cfg.GetConnectionString("Default");
                }
                catch { /* ignoramos parseo roto de appsettings */ }
            }

            // 3) Último intento: si no hay conexión, frenamos con mensaje claro
            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException(
                    "Sin cadena de conexión. Definí ENV 'ConexionSQL' o ConnectionStrings:Default en appsettings/user-secrets."
                );

            var options = new DbContextOptionsBuilder<OsteoHealthContext>()
                .UseNpgsql(conn)
                .Options;

            return new OsteoHealthContext(options);
        }
    }
}
