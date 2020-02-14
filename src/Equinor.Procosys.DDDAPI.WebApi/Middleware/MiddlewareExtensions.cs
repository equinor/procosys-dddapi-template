using Microsoft.AspNetCore.Builder;

namespace Equinor.Procosys.DDDAPI.WebApi.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void AddGlobalExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<GlobalExceptionHandler>();
    }
}
