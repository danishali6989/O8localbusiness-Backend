﻿using UserManagement.Config;
using UserManagement.DataLayer;
using UserManagement.Infrastructure.Managers;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;
using IRecurringJobManager = Hangfire.IRecurringJobManager;

namespace UserManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });

            services.AddSwaggerGen(config =>  //add this service
            {
                config.SwaggerDoc("v1", new Info { Title = "My API", Version = "V1" });

                config.OperationFilter<CustomHeader>();
            });

           /* services.AddSession(session =>
            {
                session.IdleTimeout = TimeSpan.FromSeconds(180000);
            });*/

            /* services.AddSwaggerGen(c =>
             {


                 c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                 {
                     Description = "tenent_id",
                     Name = "",
                     In = "header",
                     Type = "apiKey"
                 });

                 c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                 {
                     { "Bearer", new string[] { "Value" } }

                 });



             });
 */
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                        ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Jwt:Secret"))),
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            services.AddHttpContextAccessor();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            MiddlewareConfiguration.ConfigureEf(services, Configuration.GetConnectionString("DataConnection"));
            MiddlewareConfiguration.ConfigureUow(services);
            MiddlewareConfiguration.ConfigureManager(services);
            MiddlewareConfiguration.ConfigureRepository(services);
            MiddlewareConfiguration.ConfigureServices(services);

            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Account ERP", Version = "v1" }); });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage()
            );

            services.AddHangfireServer();

            //services.AddScoped<IRecurringJob, RecurringJob>();
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseCors("AllowAll");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR Portal API V1");
            });
            app.UseAuthentication();
           // app.UseSession();
            app.UseMvc();
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Developed-By", "Your Name");
                await next.Invoke();
            });
           /* recurringJobManager.AddOrUpdate(
                "Run Every Minute", () => serviceProvider.GetService<Infrastructure.Managers.IRecurringJobManager>().SetOverdueStatus(),
               Cron.Hourly
                );*/

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
           // _logger.LogInformation("Header added: {HeaderName}", headerName);
        }
    }
}
