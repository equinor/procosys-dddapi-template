using System.Reflection;
using Equinor.Procosys.DDDAPI.Command;
using Equinor.Procosys.DDDAPI.Query;
using Equinor.Procosys.DDDAPI.WebApi.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Procosys.DDDAPI.WebApi.DIModules
{
    public static class MediatorModule
    {
        public static void AddMediatrModules(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(MediatorModule).GetTypeInfo().Assembly,
                typeof(ICommandMarker).GetTypeInfo().Assembly,
                typeof(IQueryMarker).GetTypeInfo().Assembly
            );
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        }
    }
}
