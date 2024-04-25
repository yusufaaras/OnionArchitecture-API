using Microsoft.Extensions.DependencyInjection;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ExportService>();
        }
    }
}
