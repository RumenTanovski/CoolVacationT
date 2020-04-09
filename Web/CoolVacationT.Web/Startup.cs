﻿namespace CoolVacationT.Web
{
    using System.Reflection;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Common;
    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using CoolVacationT.Data.Seeding;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Services.Mapping;
    using CoolVacationT.Services.Messaging;
    using CoolVacationT.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            services.AddMvc().AddControllersAsServices();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IPeriodService, PeriodService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IRelaxProgramService, RelaxProgramService>();

            services.AddTransient<IFeedBackService, FeedBackService>();
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();

                        endpoints.MapControllerRoute("relaxProgram", "{controller=RelaxPrograms}/{action=Add}/{id?}");

                        endpoints.MapControllerRoute("payment", "{controller=Payments}/{action=Add}/{id?}");

                        endpoints.MapControllerRoute("reservation", "{controller=Reservations}/{action=Add}/{id?}");
                        endpoints.MapControllerRoute("reservation", "{controller=Reservations}/{action=Success}/{id?}");

                        endpoints.MapControllerRoute("period", "{controller=Periods}/{action=Add}/{id?}");

                        endpoints.MapControllerRoute("feedBack", "{controller=FeedbBacks}/{action=Add}/{id?}");
                        endpoints.MapControllerRoute("feedBack", "{controller=FeedbBacks}/{action=GetUserFeedBacks}/{id?}");
                        endpoints.MapControllerRoute("feedBack", "{controller=FeedbBacks}/{action=GetAllFeedBacks}/{id?}");

                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    });
        }
    }
}
