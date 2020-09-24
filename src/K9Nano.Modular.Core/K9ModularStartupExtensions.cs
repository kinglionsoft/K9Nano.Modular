using System;
using K9Nano.Modular.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace K9Nano.Modular
{
    public static class K9ModularStartupExtensions
    {
        public static IK9ModularAppBuilder AddK9Modular(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            IModuleNamesProvider moduleNamesProvider = new AssemblyAttributeModuleNamesProvider(hostEnvironment);

            var moduleManager = new ModuleManager(moduleNamesProvider);

            moduleManager.ConfigureServices(services, configuration, hostEnvironment);

            services.AddSingleton<IModuleManager>(moduleManager);

            var builder = new K9ModularAppBuilder(services, moduleManager);

            return builder;
        }

        public static IMvcBuilder AddControllers(this IK9ModularAppBuilder builder, Action<MvcOptions> configure = null)
        {
            var mvcBuilder = configure == null
                ? builder.Services.AddControllers()
                : builder.Services.AddControllers(configure);

            foreach (var module in builder.ModuleManager.Modules)
            {
                mvcBuilder.AddApplicationPart(module.Assembly);
            }

            return mvcBuilder;
        }


        public static IApplicationBuilder UseK9Modular(this IApplicationBuilder app)
        {
            var moduleManager = (ModuleManager)app.ApplicationServices.GetRequiredService<IModuleManager>();

            moduleManager.Configure(app, app.ApplicationServices.GetRequiredService<IWebHostEnvironment>());

            return app;
        }
    }
}
