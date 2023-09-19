using HotelFinder.Bussines.Abstract;
using HotelFinder.Bussines.Concrete;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace HotelFinder.API
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
            services.AddScoped<IHotelService, HotelMenager>();
            services.AddScoped<IHotelReposiyory, HotelRepository>();
            services.AddDbContext<HotelDbContext>(a => a.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=HotelDB;integrated security=True;"));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("Versiyon1", new OpenApiInfo
    {
        Title = "HotelFinderAPI",
        Version = "Versiyon1"

    });
});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(a => a.SwaggerEndpoint("/swagger/Versiyon1/swagger.json", "HotelFinderAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
