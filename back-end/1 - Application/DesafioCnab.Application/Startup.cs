﻿using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Repositories;
using DesafioCnab.Domain.Interfaces.Services;
using DesafioCnab.Infra.Data.Context;
using DesafioCnab.Infra.Data.Repository;
using DesafioCnab.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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

            services.AddTransient<IService<Tamanho>, BaseService<Tamanho>>();
            services.AddTransient<IService<Sabor>, BaseService<Sabor>>();
            services.AddTransient<IService<Adicional>, BaseService<Adicional>>();
            services.AddTransient<IPedidosService, PedidosService>();

            services.AddTransient<IRepository<Tamanho>, BaseRepository<Tamanho>>();
            services.AddTransient<IRepository<Sabor>, BaseRepository<Sabor>>();
            services.AddTransient<IRepository<Adicional>, BaseRepository<Adicional>>();
            services.AddTransient<IPedidosRepository, PedidosRepository>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddMvc()
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
