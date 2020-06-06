using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LojaEmpresaPequena.Context;
using MediatR;
using System.Reflection;
using LojaEmpresaPequena.Ioc;
using LojaEmpresaPequena.Services.Middlewares;

namespace LojaEmpresaPequena.Services
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
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });


            //Ef e Identity
            services.AddDbContext<LojaEmpresaPequenaIdentity>(options => options.UseMySql(Configuration.GetConnectionString("Banco"), b => b.MigrationsAssembly("LojaEmpresaPequena.Context")));
            services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<LojaEmpresaPequenaIdentity>();


            //services.AddControllers().AddNewtonsoftJson(options =>
            //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            DependencyInjector.Inject(services);

            var assemblyMediatr = Assembly.GetAssembly(typeof(LojaEmpresaPequena.Application.ProdutoMediator.Commands.SaveProduto));
            services.AddMediatR(assemblyMediatr);
            services.Configure<IdentityOptions>(options =>
            {

                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(0);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                //mudar dpos
                options.SignIn.RequireConfirmedEmail = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddCors(x => x.AddPolicy("teste", t => { t.AllowAnyOrigin(); t.AllowAnyHeader(); t.AllowAnyHeader(); t.AllowAnyMethod(); }));

            services.AddSession();
            services.AddDistributedMemoryCache();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors("teste");
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
