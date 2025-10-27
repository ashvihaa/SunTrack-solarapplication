using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunTrack.API.Data.Models;
using SunTrack.API.Services;
using SunTrack.API.Services.Projects;
using SunTrack.API.ViewModels;
using SunTrackApi.Services;

namespace SunTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSectionController : ControllerBase
    {
        private readonly IProjectServices _projectServices;

        public ProjectSectionController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet]
        [Route("GetProjectslist")]

        public async Task<IActionResult> GetProjectslist()
        {
            try
            {
                var list = await _projectServices.GetProjectslist();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProjectsVM")]
        public async Task<IActionResult> GetAllProjectsVM()
        {
            try
            {
                var projects = await _projectServices.GetAllProjectsAsync(); // returns List<ProjectViewModel>
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProjects")]
        public async Task<IActionResult> GetProjects(SearchVM search)
        {
            try
            {
                var projects = await _projectServices.GetProjectsAsync(search);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("SaveProject")]
        public async Task<IActionResult> SaveProject(ProjectRequestDto model)
        {
            var result = await _projectServices.SaveProjectAsync(model);
            return Ok(new { message = result });
        }

        [HttpGet("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectServices.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound(new { message = "Project not found" });

            return Ok(project);
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectServices.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPost("SaveMapping")]
        public async Task<IActionResult> SaveMapping(ProjectProductMappingRequestDto model)
        {
            var result = await _projectServices.AddOrUpdateMappingAsync(model);
            return Ok(new { message = result });
        }

        [HttpGet("GetMappings/{projectId}")]
        public async Task<IActionResult> GetMappings(int projectId)
        {
            var productIds = await _projectServices.GetProductIdsByProjectAsync(projectId);
            return Ok(productIds);
        }

        [HttpDelete("DeleteProject/{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var result = await _projectServices.DeleteProjectAsync(projectId);
            return Ok(new { message = result });
        }

        [HttpPut("RestoreProject/{projectId}")]
        public async Task<IActionResult> RestoreProject(int projectId)
        {
            var result = await _projectServices.RestoreProjectAsync(projectId);
            return Ok(new { message = result });
        }

    }
}

