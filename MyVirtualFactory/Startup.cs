using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyVirtualFactory
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
