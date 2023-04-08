global using CalcTask.WebAPI.Library;
global using CalcTask.WebAPI.Library.Providers;
global using CalcTask.WebAPI.Library.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http.Headers;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CalcTask.WebAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostEnv;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnv)
        {
            Configuration = configuration;
            _hostEnv = hostEnv;
        }

        public void ConfigureServices(IServiceCollection services, Serilog.ILogger logger)
        {
            services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);

            if (_hostEnv.IsDevelopment())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });
            }

            services.AddHttpClient(name: "CalcTask_API",
                configureClient: options =>
                {
                    options.BaseAddress = new Uri("https://localhost:5001");
                    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
                });

            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IMessagesProvider, DefaultMessagesProvider>();

            services.AddSingleton(logger);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CalcTask_Web_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalcTask_Web_API v1");
                    c.SupportedSubmitMethods(new[] { SubmitMethod.Get, SubmitMethod.Put, SubmitMethod.Post, SubmitMethod.Delete, SubmitMethod.Patch });
                });

                app.UseCors();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
