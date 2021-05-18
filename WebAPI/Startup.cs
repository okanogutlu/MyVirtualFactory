using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Singletons:
            {
                {
                    services.AddSingleton<IOperationServices, OperationManager>();
                    services.AddSingleton<IOrderItemServices, OrderItemManager>();
                    services.AddSingleton<IOrderServices, OrderManager>();
                    services.AddSingleton<IProductServices, ProductManager>();
                    services.AddSingleton<IProductTypeServices, ProductTypeManager>();
                    services.AddSingleton<IStockServices, StockManager>();
                    services.AddSingleton<ISubProductTreeServices, SubProductTreeManager>();
                    services.AddSingleton<IUserServices, UserManager>();
                    services.AddSingleton<IWorkCenterOperationServices, WorkCenterOperationManager>();
                    services.AddSingleton<IWorkCenterServices, WorkCenterManager>();
                }
                {
                    services.AddSingleton<IOperationDAL, EfOperationDAL>();
                    services.AddSingleton<IOrderDAL, EfOrderDAL>();
                    services.AddSingleton<IOrderItemDAL, EfOrderItemDAL>();
                    services.AddSingleton<IProductDAL, EfProductDAL>();
                    services.AddSingleton<IUserDAL, EfUserDAL>();
                    services.AddSingleton<IWorkCenterDAL, EfWorkCenterDAL>();
                    services.AddSingleton<IWorkCenterOperationDAL, EfWorkCenterOperationDAL>();
                    services.AddSingleton<ISubProductTreeDAL, EfSubProductTreeDAL>();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
