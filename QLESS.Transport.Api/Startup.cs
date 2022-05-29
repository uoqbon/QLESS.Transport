using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QLESS.Transport.Business.Components;
using System;
using System.IO;

namespace QLESS.Transport.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public bool IsDebug() => HostingEnvironment.IsEnvironment("Debug");

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            if (!HostingEnvironment.IsProduction())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QLESS Transport API", Version = "v1" });
                    c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QLESS.Transport.Api.xml"));
                });
            }

            services.AddBusiness(Configuration.GetConnectionString("QLESSTransport"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!HostingEnvironment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var swaggerUrl = IsDebug() ? string.Empty : ("/" + new DirectoryInfo(env.ContentRootPath).Name).Replace("/wwwroot", string.Empty);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QLESS Transport API");
                });
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
