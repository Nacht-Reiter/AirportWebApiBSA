using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AirportWebApiBSA
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
            services.AddMvc();
            services.AddScoped<DAL.Interfaces.IUnitOfWork, DAL.Repositories.UnitOfWork> ();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<BLL.Interfaces.IService<PilotDTO>, BLL.Services.PilotService>();
            services.AddTransient<BLL.Interfaces.IService<StewardessDTO>, BLL.Services.StewardessService>();
            services.AddTransient<BLL.Interfaces.IService<AirCraftDTO>, BLL.Services.AirCraftService>();
            services.AddTransient<BLL.Interfaces.IService<AirCraftTypeDTO>, BLL.Services.AirCraftTypeService>();
            services.AddTransient<BLL.Interfaces.IService<CrewDTO>, BLL.Services.CrewService>();
            services.AddTransient<BLL.Interfaces.IService<DepartureDTO>, BLL.Services.DepartureService>();
            services.AddTransient<BLL.Interfaces.IService<FlightDTO>, BLL.Services.FlightService>();
            services.AddTransient<BLL.Interfaces.IService<TicketDTO>, BLL.Services.TicketService>();
            services.AddDbContext<AirportContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AirportDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();

            }

            app.UseMvc();
        }
    }
}
