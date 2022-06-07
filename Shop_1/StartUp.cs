using Shop_1.Data;
using Shop_1.Data.Interfaces;
using Shop_1.Data.mocks;
using Microsoft.EntityFrameworkCore;

namespace Shop_1
{
    public class StartUp
    {

        private IConfigurationRoot _confstring;

        //конструктор
        public StartUp(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv) {
            //записываем в переменную файл с строкой подключения, чтобы потом добавить его в сервисы
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }


        /// <summary>
        /// настройка сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //указываем, какой использовать sql-сервер, с помощью переменной, в которой хранятся настройки из файла 
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));

            //связываем интерфейс с классом, реализующим этот интерфейс
            services.AddTransient<IAllProducts,MockProducts>();
            services.AddTransient<IProductsCategory, MockCategory>();

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
