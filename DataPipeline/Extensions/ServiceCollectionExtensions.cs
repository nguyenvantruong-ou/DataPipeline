using DataPipeline.Models.UnitOfWork;

namespace DataPipeline.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }
    }
}
