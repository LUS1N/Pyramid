using Microsoft.Extensions.DependencyInjection;
using Pyramid.Solver;

namespace Pyramid.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPyramidSolver(this IServiceCollection services)
        {
            services.AddScoped<IPyramidSolver, PyramidSolver>();

            return services;
        }
    }
}