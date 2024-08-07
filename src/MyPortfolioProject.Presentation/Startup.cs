using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.Mappings;
using MyPortfolioProject.Application.Services;
using MyPortfolioProject.Core.Interfaces;
using MyPortfolioProject.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolioProject.Infrastructure.Repositories;
using MyPortfolioProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MyPortfolioProject.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get;  }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(ScheduleMeetingUseCaseHandler).Assembly
            ));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyPortfolioProject.Presentation v1"));
            }
            else
            {
                app.UseExceptionHandler(exceptionHandlerApp =>
                {
                    exceptionHandlerApp.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";
                        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                        var exception = exceptionHandlerPathFeature?.Error;

                        var problemDetails = new ProblemDetails
                        {
                            Status = StatusCodes.Status500InternalServerError,
                            Title = "An error occurred while processing your request.",
                            Detail = exception?.Message
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                    });
                });

                app.UseHsts();
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
