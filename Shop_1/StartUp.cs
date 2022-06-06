using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shop_1.Data.Interfaces;
using Shop_1.Data.mocks;

namespace Shop_1
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //связывает интерфейс с классом, реализующим этот интерфейс
            services.AddTransient<IAllProducts,MockProducts>();
            services.AddTransient<IProductsCategory, MockCategory>();

            //MvcOptions.EnableEndpointRouting = false;

            services.AddMvc();
         
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}");
            });
            
        }
    }
}
