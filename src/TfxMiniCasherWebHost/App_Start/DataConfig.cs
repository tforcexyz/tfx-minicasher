using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xyz.TForce.MiniCasher.Data.Repositories.Accounting;

namespace Xyz.TForce.MiniCasher
{

  public class DataConfig
  {

    public static void ConfigureServices(IServiceCollection services, ContainerBuilder containerBuilder, IConfiguration configuration)
    {
      string connectionString = configuration.GetConnectionString("Default");
      DbContextOptions<AccountingDbContext> contextOptions = new DbContextOptionsBuilder<AccountingDbContext>()
        .UseSqlServer(connectionString, UseSqlServerAction)
        .Options;
      _ = containerBuilder.RegisterInstance(contextOptions).SingleInstance();
    }

    private static void UseSqlServerAction(SqlServerDbContextOptionsBuilder builder)
    {
    }

    public static void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
    {
    }
  }
}
