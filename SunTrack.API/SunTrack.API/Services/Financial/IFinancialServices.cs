using Microsoft.AspNetCore.Mvc;
using SunTrack.API.ViewModels.FinancialVM;

namespace SunTrack.API.Services.Financial
{
    public interface IFinancialServices
    {
        Task<List<FinancialStatusVM>> GetAllFinancialStatusAsync();
        Task<FinancialStatusVM?> GetFinancialStatusByIdAsync(int id);
        Task<bool> AddFinancialStatusAsync(FinancialStatusVM model);
        Task<bool> SoftDeleteFinancialStatusAsync(int id, int updatedBy);
        
    }
}
