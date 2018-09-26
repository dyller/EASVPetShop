using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PetApp.Infrastructure;
using PetApp.Infrastructure.Repository;
using PetApp.Infrastructure.SQLRepositorie;
using petShop.Core.Entity;

namespace PetShopAPI
{
    public class Startup
    { 
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
            FAKEDB.InitData();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PetShopAppContext>(
                opt => opt.UseSqlite("Data Source=customerApp.db"));
            
            services.AddScoped<IPetRepository1, SQLPetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, SQLOwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
                    DBInitilizer.SeedDB(ctx);

                }
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
