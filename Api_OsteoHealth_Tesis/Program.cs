using Api_OsteoHealth_Tesis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;

/// <summary>
/// Clase con el metodo main
/// </summary>
public class Program
{
    /// <summary>
    /// 
    /// </summary>
    public static IServiceProvider ServiceProvider;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {

        var host = WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
        ServiceProvider = host.Services;
        host.Run();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>();
}
