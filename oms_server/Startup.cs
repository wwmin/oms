using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using oms.model;
using oms.service;

namespace oms_server
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            #region Service DI
            services.AddScoped<IRunCmdService, RunCmdService>();
            #endregion
            #region Config DI
            var operationsConfig = Configuration.GetSection("Operations");
            services.Configure<List<OperationsConfig>>(operationsConfig);
            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "极简运维平台",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "wwmin",
                        Email = "wwei.min@163.com"
                    }
                });
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                foreach (var file in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
                {
                    c.IncludeXmlComments(file, true);
                }
                //Authorization的设置
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "请输入验证的jwt,示例: Bearer {jwt}",
                //    Name = "Authorization",

                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT"
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        new string[]{ }
                //    }
                //});
            });
            #endregion

            #region Cors
            //signalr跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSome", policy =>
                {
                    policy
                    .AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromSeconds(60))
                    .AllowAnyMethod()
                    .WithOrigins(Configuration["AllowCorsUrls"].Split(","))
                    .AllowCredentials();
                });
            });
            #endregion
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "oms_server v1"));
            }
            app.UseCors("AllowSome");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
