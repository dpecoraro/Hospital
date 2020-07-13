using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUSINESSLOGIC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPI.ApiServices;
using WebAPI.ApiServices.Interface;
using WebAPI.Repository;
using WebAPI.Repository.Context;
using WebAPI.Repository.Interface;
using WebAPI.Security;
using WebAPI.Security.Entities;

namespace WebAPI
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();

            #region [ Context e Repositórios ]
            services.AddDbContext<HospitalContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HospitalDatabase")));

            services.AddScoped<IHospitalRepository, HospitalRepository>(r => new HospitalRepository(Configuration.GetSection("AppSettings").Get<AppSettings>().HospitalDatabase));
            
            #endregion

            #region [ Serviços ]
            services.AddScoped<IHospitalService, HospitalService>();

            #endregion


            #region [ JWT Config ]

            SigninConfiguration signinConfiguration = new SigninConfiguration();
            services.AddSingleton(signinConfiguration);

            TokenConfiguration tokenConfiguration = new TokenConfiguration();
            //new ConfigureFromConfigurationOptions<TokenConfiguration>(settings.TokenConfiguration)
            //    .Configure(tokenConfiguration);

            services.AddSingleton(tokenConfiguration);

            services.AddJwtSecurity(signinConfiguration, tokenConfiguration);

            #endregion

            services.AddControllers();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
