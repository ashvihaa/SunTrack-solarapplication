using SunTrack.API.ViewModels.InstallationVM;
using System.Threading.Tasks;

namespace SunTrack.API.Services.Installation
{
    public interface IInstallationServices
    {
        Task<bool> AddInstallationStatusAsync(InstallationStatusVM model);
        Task<List<InstallationStatusVM>> GetAllInstallationStatusesAsync();
        Task<(List<InstallationStatusVM> Items, int TotalCount)> GetInstallationStatusesAsync(string? search, int pageNumber, int pageSize);
        Task<bool> UpdateInstallationStatusAsync(InstallationStatusVM model);
        Task<bool> DeleteInstallationStatusAsync(int id);


    }
}
