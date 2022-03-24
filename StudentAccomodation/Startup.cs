using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentAccomodation.Services.Interfaces;
using StudentAccomodation.Services.Services.ApartmentService;
using StudentAccomodation.Services.Services.DormitoryService;
using StudentAccomodation.Services.Services.LeasingService;
using StudentAccomodation.Services.Services.RoomService;
using StudentAccomodation.Services.Services.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation
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
            services.AddRazorPages();
            
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ADOStudent>();
            
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ADORoom>(); 
           
            services.AddScoped<ILeasingService, LeasingService>();
            services.AddScoped<ADOLeasing>();

            services.AddScoped<IDormitoryService, DormitoryService>();
            services.AddScoped<ADODormitory>();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<ADOApartment>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
