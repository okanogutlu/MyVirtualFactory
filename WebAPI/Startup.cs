using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Entities;
using Core.Utilities.IOC;
using Core.Utilities.Security.Enrcyption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            //    services.AddDbContext<MSSQLDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("MSSQLDbContext")));
            //    services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllers();

            //Singletons:
            {
                services.AddSingleton<IOrder, Entities.Concrete.Order>();

                {
                    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    services.AddSingleton<IOperationServices, OperationManager>();
                    services.AddSingleton<IOrderItemServices, OrderItemManager>();
                    services.AddSingleton<IOrderServices, OrderManager>();
                    services.AddSingleton<IProductServices, ProductManager>();
                    services.AddSingleton<IStockServices, StockManager>();
                    services.AddSingleton<ISubProductTreeServices, SubProductTreeManager>();
                    services.AddTransient<IUserServices, UserManager>();
                    services.AddSingleton<IWorkCenterOperationServices, WorkCenterOperationManager>();
                    services.AddSingleton<IWorkCenterServices, WorkCenterManager>();
                    services.AddTransient<IAuthServices, AuthManager>();
                    services.AddSingleton<ITokenHelper, JwtHelper>();
                }
                {
                    services.AddSingleton<IStockDAL, EfStockDAL>();
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
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            ServiceTool.Create(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
