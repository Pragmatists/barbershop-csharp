using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Domain;
using BarberShop.Infrastructure.InMemoryDataStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BarberShop
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IAppointmentsRepository, InMemoryAppointmentsRepository>(
                provider => Seed(new InMemoryAppointmentsRepository()));

            var connection = @"Server=(localdb)\mssqllocaldb;Database=BarberShop.Dev;Trusted_Connection=True;";
            services.AddDbContext<BarberShopContext>(options => options.UseSqlServer(connection));
        }

        private static InMemoryAppointmentsRepository Seed(InMemoryAppointmentsRepository inMemoryAppointmentsRepository)
        {
            inMemoryAppointmentsRepository.Store(new Appointment
            {
                Client = "Janina Nowak",
                ID = 1,
                Time = new DateTime(2010, 3, 1, 12, 30, 0)
            });
            return inMemoryAppointmentsRepository;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }

    public class BarberShopContext : DbContext
    {
        public BarberShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } 
    }
}
