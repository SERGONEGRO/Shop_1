using Shop_1.Data.Interfaces;
using Shop_1.Data.mocks;

namespace Shop_1
{
    public class StartUp
    {
        /// <summary>
        /// настройка сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //связывает интерфейс с классом, реализующим этот интерфейс
            services.AddTransient<IAllProducts,MockProducts>();
            services.AddTransient<IProductsCategory, MockCategory>();

            //MvcOptions.EnableEndpointRouting = false; устарело

            services.AddMvc();
         
        }

    
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute(); устарело
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}");
            });
            
        }
    }
}
