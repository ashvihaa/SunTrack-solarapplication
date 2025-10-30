using SunTrack.API.Services.Financial;
using SunTrack.API.Services.Installation;
using SunTrack.API.Services.Projects;
using SunTrackApi.Services;

namespace SunTrack.API
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        { 
        services.AddScoped<IProjectServices, ProjectServices>();
        services.AddScoped<IInstallationServices, InstallationServices>();
        services.AddScoped<IFinancialServices, FinancialServices>();
            return services;
        }
    }
}
