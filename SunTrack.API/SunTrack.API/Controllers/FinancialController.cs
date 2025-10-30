using Microsoft.AspNetCore.Mvc;
using SunTrack.API.Services.Financial;
using SunTrack.API.ViewModels.FinancialVM;

namespace SunTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialController : ControllerBase
    {
        private readonly IFinancialServices _financialServices;

        public FinancialController(IFinancialServices financialServices)
        {
            _financialServices = financialServices;
        }

        //Get all financial status records
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _financialServices.GetAllFinancialStatusAsync();

                if (data == null || data.Count == 0)
                    return NotFound("No financial records found.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get financial record by Id
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var record = await _financialServices.GetFinancialStatusByIdAsync(id);

                if (record == null)
                    return NotFound($"No record found with ID {id}");

                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // SOFT DELETE (Mark record as inactive)
        [HttpPatch("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id, int updatedBy = 1)
        {
            try
            {
                var result = await _financialServices.SoftDeleteFinancialStatusAsync(id, updatedBy);

                if (!result)
                    return NotFound($"No active financial record found with ID {id}.");

                return Ok(new { message = $"Financial record with ID {id} has been deactivated (soft deleted)." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFinancialStatuses")]
        public async Task<IActionResult> GetFinancialStatuses(string? search, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (items, totalCount) = await _financialServices.GetFinancialStatusesAsync(search, pageNumber, pageSize);

                if (totalCount == 0)
                    return NotFound("No financial records found.");

                return Ok(new
                {
                    totalCount,
                    pageNumber,
                    pageSize,
                    items
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }






        //UPDATE Financial Record
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateFinancialStatus([FromBody] FinancialStatusVM model)
        {
            if (model == null || model.Id == 0)
                return BadRequest("Invalid financial record data.");

            try
            {
                var success = await _financialServices.UpdateFinancialStatusAsync(model);

                if (!success)
                    return NotFound($"No active financial record found with ID {model.Id}.");

                return Ok(new { message = "Financial record updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

    


 
