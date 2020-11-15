using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xyz.TForce.DependencyInjection;
using Xyz.TForce.MiniCasher.Application.Logic;
using Xyz.TForce.MiniCasher.Data.Repositories;

namespace Xyz.TForce.MiniCasher
{

  public class DependencyConfig
  {

    public static void ConfigureServices(IServiceCollection services, ContainerBuilder containerBuilder, IConfiguration configuration)
    {
      _ = containerBuilder.Register<ServiceFactory>(context =>
      {
        IComponentContext c = context.Resolve<IComponentContext>();
        return t => { return c.Resolve(t); };
      });
      _ = containerBuilder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
      containerBuilder.RegisterAutoInjectClasses(typeof(InfrastructureDataModule).Assembly);
      containerBuilder.RegisterAutoInjectClasses(typeof(AppLogicModule).Assembly);
      IContainer container = containerBuilder.Build();
      services.AddSingleton(container);
    }

    public static void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
    {
    }
  }
}
