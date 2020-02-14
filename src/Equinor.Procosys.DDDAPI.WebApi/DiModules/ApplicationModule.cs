using Equinor.Procosys.DDDAPI.Command.EventHandlers;
using Equinor.Procosys.DDDAPI.Domain;
using Equinor.Procosys.DDDAPI.Domain.Events;
using Equinor.Procosys.DDDAPI.Infrastructure;
using Equinor.Procosys.DDDAPI.WebApi.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Procosys.DDDAPI.WebApi.DIModules
{
    public static class ApplicationModule
    {
        public static void AddApplicationModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DDDAPIContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DDDAPIContext"));
            });

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            // Transient - Created each time it is requested from the service container


            // Scoped - Created once per client request (connection)
            services.AddScoped<IPlantProvider, PlantProvider>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<DDDAPIContext>());
            services.AddScoped<IReadOnlyContext>(x => x.GetRequiredService<DDDAPIContext>());

            // Singleton - Created the first time they are requested
            services.AddSingleton<ITimeService, TimeService>();
        }
    }
}
