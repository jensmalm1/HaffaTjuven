using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Data;

namespace API
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

            string username = "GW";
            string password = "haffatjuven1!";

            services.AddDbContext<CrimeContext>(options =>

                //options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EfCrime; Trusted_Connection = True; "));
                    options.UseSqlServer($"Server=tcp:sql-haffatjuven-dev.database.windows.net,1433;Initial Catalog=db-haffatjuven;Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddDistributedMemoryCache();
      
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(40);   
            });
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseDirectoryBrowser();

        }
    }
}
