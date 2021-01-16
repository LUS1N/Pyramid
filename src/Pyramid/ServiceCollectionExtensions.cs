using Microsoft.Extensions.DependencyInjection;
using Pyramid.Solver;
using Pyramid.Solver.Builder.Factory;

namespace Pyramid
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPyramidSolver(this IServiceCollection services)
        {
            services.AddScoped<IPyramidSolver, PyramidSolver>();
            services.AddScoped<IPyramidGraphBuilderFactory, PyramidGraphBuilderFactory>();

            return services;
        }
    }
}