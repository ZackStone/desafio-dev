using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using DesafioCnab.Infra.Data.Context;
using DesafioCnab.Infra.Data.Repository;
using DesafioCnab.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace DesafioCnab.Application
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
            services.AddDbContext<DesafioCnabContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionString:DesafioCnabDB"]);
            });

            services.AddTransient<ICnabFileService, CnabFileService>();
            services.AddTransient<IService<Transacao>, BaseService<Transacao>>();

            services.AddTransient<IRepository<Transacao>, BaseRepository<Transacao>>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services
                .AddMvc(opts => {
                    opts.EnableEndpointRouting = false;
                })
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
