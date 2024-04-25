using Microsoft.Extensions.DependencyInjection;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services.Concrete;
using OnionArchitectureOgrenme.Infrastructure.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITextService, TextService>();
        }
    }
}
