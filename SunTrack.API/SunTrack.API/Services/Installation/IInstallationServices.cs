using SunTrack.API.ViewModels.InstallationVM;

namespace SunTrack.API.Services.Installation
{
    public interface IInstallationServices
    {
        Task<List<InstallationStatusVM>> GetInstallationStatusAsync(InstallationStatusVM searchVm);
        Task<bool> AddOrUpdateInstallationStatusAsync(InstallationStatusVM model);

    }
}
