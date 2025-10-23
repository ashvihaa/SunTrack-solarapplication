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
                var projects = await _projectServices.GetProjectslist();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
