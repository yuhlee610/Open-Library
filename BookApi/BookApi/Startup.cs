using AspNetCoreRateLimit;
using BookApi.Configuration;
using BookApi.Data;
using BookApi.IRepository;
using BookApi.Repository;
using BookApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi
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
            // Register ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*
             * Add Cors:
             * - Allow every one can consume API
             */
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Configure Identity 
            services.AddAuthentication();
            services.ConfigureIdentity();

            // Đăng ký UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Đăng ký sử dụng AutoMapper
            services.AddAutoMapper(typeof(MapperInitializer));

            // Đăng ký AuthManager
            services.AddTransient<IAuthManager, AuthManager>();

            // Config JWT
            services.ConfigureJWT(Configuration);

            /*
             * Đăng ký sử dụng memmory cache
             * Dùng cho Rate limit:
             * App sử dụng memory cache để nhận biết client nào đang request, số lượng request của client
             */
            services.AddMemoryCache();

            // Đăng ký Rate Limit
            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor();

            // Đăng ký Caching
            services.ConfigureHttpCacheHeaders();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookApi v1"));
            }

            app.UseHttpsRedirection();

            // Consume Policy Cors name "AllowAll"
            app.UseCors("AllowAll");

            /* 
             * Sử dụng middlleware caching
             * Giải thích: 
             * - http://example.com?key1=value1 : return from server
             * - http://example.com?key1=value1 : return from middleware
             * - http://example.com?key1=value2	: return from server
             * Request đầu tiên được server response và cache trong middleware
             * Request thứ 2 giống với Request 1 nên sẽ được response bởi middleware
             * Request thứ 3 chưa được cache nên sẽ do server Response
            */
            app.UseResponseCaching();
            app.UseHttpCacheHeaders();

            // Đăng ký middleware Rate limit
            app.UseIpRateLimiting();

            app.UseRouting();

            // Add pipeline Authorize, Authen
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
