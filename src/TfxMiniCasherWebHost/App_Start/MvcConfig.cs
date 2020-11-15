using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Xyz.TForce.MiniCasher
{

  public class MvcConfig
  {

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
      services.AddMvc();
    }

    public static void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc(UseMvc);
    }

    private static void UseMvc(IRouteBuilder configureRoutes)
    {
      configureRoutes.MapRoute(
        "default",
        "{controller=Home}/{action=Index}"
      );
    }
  }
}
