using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESP.Core.Account.Web.Permission;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Provider;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Data.PostgreSql;
using ESP.Standard.Infrastructure.Install;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESP.Core.Account.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/login/index");
                options.AccessDeniedPath = new PathString("/*");
                options.Cookie.Domain = ".domain.dev";
                options.Cookie.Name = "sso";
                options.Cookie.Path = "/";
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.Install();
            //services.AddTransient<IOrganizationProvider, OrganizationProvider>();
            //services.AddTransient<IUserProvider, UserProvider>();
            //services.AddTransient<IRoleProvider, RoleProvider>();
            //services.AddTransient<IPermissionProvider, PermissionProvider>();
            //services.AddTransient<IElementProvider, ElementProvider>();
            //services.AddTransient<IMenuProvider, MenuProvider>();

            //services.AddTransient<UserDao, UserDao>();
            //services.AddTransient<AccountDao, AccountDao>();
            //services.AddTransient<OrganizationDao, OrganizationDao>();

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var dbMapping = new ConcurrentDictionary<string, string>();
            dbMapping.GetOrAdd("Account", "Host=127.0.0.1;Username=postgres;Password=xuyan871206;Database=account;Pooling=true");
            ConnectionStringInitializer.Init(dbMapping);



        }
    }
}
