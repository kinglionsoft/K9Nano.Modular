using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace K9Nano.Modular
{
    public interface IModuleStartup
    {
        int Order { get; }

        void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}