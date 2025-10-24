using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunTrack.API.Data.Models;
using SunTrack.API.Services.Projects;
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
                var projects = await _projectServices.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetFilteredProjects")]
        public async Task<IActionResult> GetFilteredProjects(
                int? customerId = null,
                int? statusId = null,
                string? category = null,
                string? projectName = null)
        {
            try
            {
                var projects = await _projectServices.GetFilteredProjects(
                    customerId, statusId, category, projectName);

                return Ok(projects); // 200 JSON list
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400 on error (simple for now)
            }
        }

        [HttpGet]
        [Route("GetPaginationAsync")]
        public async Task<IActionResult> GetAllProjectsVM(
             int pageNumber = 1,
             int pageSize = 10)
        {
            try
            {
                var projects = await _projectServices.GetPaginationAsync(pageNumber, pageSize);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
