using SunTrack.API.Data.Models;
using SunTrack.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunTrack.API.Services.Projects
{
    public interface IProjectServices
    {
        Task<List<Project>> GetProjectslist();
    }
}


public interface IProjectService
{
    // This method will return a list of all projects as ProjectViewModel
    Task<List<ProjectViewModel>> GetAllProjectsAsync();
}
