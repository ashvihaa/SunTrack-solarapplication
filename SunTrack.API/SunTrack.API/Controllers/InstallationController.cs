using Microsoft.AspNetCore.Mvc;
using SunTrack.API.Services.Installation;
using SunTrack.API.ViewModels.InstallationVM;
using System;
using System.Threading.Tasks;

namespace SunTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstallationController : ControllerBase
    {
        private readonly IInstallationServices _installationServices;

        public InstallationController(IInstallationServices installationServices)
        {
            _installationServices = installationServices;
        }

       
        /// Add new Installation Status
        /// </summary>
        [HttpPost]
        [Route("AddInstallation")]

        public async Task<IActionResult> AddInstallationStatus(InstallationStatusVM model)
        {
            if (model == null)
                return BadRequest("Invalid data received");

            try
            {
                var isSuccess = await _installationServices.AddInstallationStatusAsync(model);

                if (isSuccess)
                {
                    return Ok(new { message = "Installation Status added successfully." });
                }

                return BadRequest("Failed to save installation status.");

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetAllInstallationStatus")]
        public async Task<IActionResult> GetAllInstallationStatus()
        {
            try
            {
                var result = await _installationServices.GetAllInstallationStatusesAsync();

                if (result == null || result.Count == 0)
                    return NotFound("No installation status records found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// Get with search & pagination
        [HttpGet("list")]
        public async Task<IActionResult> List(string? search,int pageNumber = 1,int pageSize = 10)
        {
            try
            {
                var (items, total) = await _installationServices.GetInstallationStatusesAsync(search, pageNumber, pageSize);
                if (total == 0) return NotFound("No records.");

                return Ok(new
                {
                    total,
                    pageNumber,
                    pageSize,
                    items
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
