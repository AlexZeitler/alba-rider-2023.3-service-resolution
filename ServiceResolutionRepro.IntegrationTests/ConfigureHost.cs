using JasperFx.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceResolutionRepro.IntegrationTests;

public interface IIdGenerator
{
  Guid New();
}

public class MartenIdGenerator : IIdGenerator
{
  public Guid New() => CombGuidIdGeneration.NewGuid();
}

public static class ConfigureHost
{
  public static IHostBuilder GetHostBuilder()
  {
    var hostBuilder = Host.CreateDefaultBuilder();

    hostBuilder.ConfigureWebHostDefaults(
      builder =>
      {
        builder.ConfigureServices(
          (
            _,
            services
          ) =>
          {
            services.AddScoped<IIdGenerator, MartenIdGenerator>();
            services.AddMvc();
          }
        );
        builder.Configure(
          (
            _,
            app
          ) =>
          {
            app.UseRouting();
            app.UseEndpoints(
              endpoints => { endpoints.MapControllers(); }
            );
          }
        );
      }
    );

    return hostBuilder;
  }
}
