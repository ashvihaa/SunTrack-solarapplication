using SunTrack.API.Services.Projects;
using SunTrackApi.Services;

namespace SunTrack.API
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        { 
        services.AddScoped<IProjectServices, ProjectServices>();
            return services;
        }
    }
}
