using SunTrack.API.Data.Models;
using SunTrack.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunTrack.API.Services.Projects
{
    public interface IProjectServices
    {
        Task<List<Project>> GetProjectslist();
        Task<List<ProjectViewModel>> GetAllProjectsAsync();
        Task<List<ProjectViewModel>> GetProjectsAsync(SearchVM search);
        Task<string> SaveProjectAsync(ProjectRequestDto model);
        Task<ProjectRequestDto> GetProjectByIdAsync(int projectId);
        Task<List<ProjectRequestDto>> GetAllProjectsDtoAsync();
        Task<string> AddOrUpdateMappingAsync(ProjectProductMappingRequestDto model);
        Task<List<int>> GetProductIdsByProjectAsync(int projectId);
    }

}