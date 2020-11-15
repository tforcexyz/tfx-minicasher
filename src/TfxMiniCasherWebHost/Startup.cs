using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Xyz.TForce.MiniCasher
{

  public class Startup
  {

    private readonly IConfiguration _configuration;
    private readonly ContainerBuilder _containerBuilder;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
      _containerBuilder = new ContainerBuilder();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      DataConfig.ConfigureServices(services, _containerBuilder, _configuration);
      MvcConfig.ConfigureServices(services, _configuration);
      DependencyConfig.ConfigureServices(services, _containerBuilder, _configuration);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      DataConfig.ConfigureApp(app, env);
      MvcConfig.ConfigureApp(app, env);
      DependencyConfig.ConfigureApp(app, env);
    }

  }
}
