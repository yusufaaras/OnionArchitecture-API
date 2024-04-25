using Microsoft.Extensions.DependencyInjection;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Presistence.DbContexts;
using OnionArchitectureOgrenme.Presistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Presistence
{
    public static class ServiceRgistration
    {
        public static void AddPersistneceServices(this IServiceCollection services)
        {

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<OnionArchDbContext>();
        }
    }
}
