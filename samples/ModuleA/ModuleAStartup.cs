using K9Nano.Modular;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleA
{
    public class ModuleAStartup: IModuleStartup
    {
        public int Order { get; set; } = 0;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}