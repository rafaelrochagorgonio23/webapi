using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
 
namespace MarcDias.Api
{
public class Program
{
public static void Main(string[] args)
{
var host = new WebHostBuilder()
.UseKestrel()
.UseStartup<Program>()
.Build();
host.Run();
}

public void ConfigureServices(IServiceCollection services)
{
        //Old Way
        services.AddMvc();
        // New Ways
        services.AddRazorPages();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
        /*
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        */
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });

}





 /*
public void ConfigureServices(IServiceCollection services)
{
services.AddMvc();
}
 
public void Configure(IApplicationBuilder app)
{
app.UseMvcWithDefaultRoute();
}

//1º tentativa retirar ConfigureServices
public void ConfigureServices(IService Collection services)

{
	
    services.AddMvc(option -> option.EnableEndpointRouting = false);
	
    services.AddOptions();
}
*/
}
}