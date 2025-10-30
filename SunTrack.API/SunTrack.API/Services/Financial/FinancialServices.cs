using Microsoft.EntityFrameworkCore;
using SunTrack.API.Data;
using SunTrack.API.Data.Models;
using SunTrack.API.ViewModels.FinancialVM;

namespace SunTrack.API.Services.Financial
{
    public class FinancialServices : IFinancialServices
    {
        private readonly SunTrackContext _context;

        public FinancialServices(SunTrackContext context)
        {
            _context = context;
        }

        // Get all financial status records
        public async Task<List<FinancialStatusVM>> GetAllFinancialStatusAsync()
        {
            try
            {
                var result = await _context.FinancialStatuses
                    .Where(x => x.IsActive)
                    .Select(x => new FinancialStatusVM
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProjectId = x.ProjectId,
                        ProjectDate = x.ProjectDate,
                        Budget = x.Budget,
                        Document = x.Document,
                        Status = x.Status,
                        PurchaseInvoice = x.PurchaseInvoice,
                        ReceivedAmount = x.ReceivedAmount,
                        ExpenseAmount = x.ExpenseAmount,
                        ExpenseReason = x.ExpenseReason,
                        AdminApproval = x.AdminApproval,
                        PaymentMode = x.PaymentMode,
                        PaymentRefNo = x.PaymentRefNo,
                        PaymentDate = x.PaymentDate,
                        Reimbursement = x.Reimbursement,
                        RemarksInternal = x.RemarksInternal,
                        IsActive = x.IsActive,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .ToListAsync();

                return result;
            }
            catch
            {
                return new List<FinancialStatusVM>();
            }
        }

        //Get financial record by Id
        public async Task<FinancialStatusVM?> GetFinancialStatusByIdAsync(int id)
        {
            try
            {
                var record = await _context.FinancialStatuses
                    .Where(x => x.IsActive && x.Id == id)
                    .Select(x => new FinancialStatusVM
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProjectId = x.ProjectId,
                        ProjectDate = x.ProjectDate,
                        Budget = x.Budget,
                        Document = x.Document,
                        Status = x.Status,
                        PurchaseInvoice = x.PurchaseInvoice,
                        ReceivedAmount = x.ReceivedAmount,
                        ExpenseAmount = x.ExpenseAmount,
                        ExpenseReason = x.ExpenseReason,
                        AdminApproval = x.AdminApproval,
                        PaymentMode = x.PaymentMode,
                        PaymentRefNo = x.PaymentRefNo,
                        PaymentDate = x.PaymentDate,
                        Reimbursement = x.Reimbursement,
                        RemarksInternal = x.RemarksInternal,
                        IsActive = x.IsActive,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    })
                    .FirstOrDefaultAsync();

                return record;
            }
            catch
            {
                return null;
            }
        }



        // Add Financial Record
        public async Task<bool> AddFinancialStatusAsync(FinancialStatusVM model)
        {
            try
            {
                if (model == null)
                    return false;

                var entity = new FinancialStatus
                {
                    CustomerId = model.CustomerId,
                    ProjectId = model.ProjectId,
                    ProjectDate = model.ProjectDate ?? DateTime.Now,
                    Budget = (decimal)model.Budget,
                    Document = model.Document,
                    Status = model.Status,
                    PurchaseInvoice = model.PurchaseInvoice,
                    ReceivedAmount = model.ReceivedAmount,
                    ExpenseAmount = model.ExpenseAmount,
                    ExpenseReason = model.ExpenseReason,
                    AdminApproval = model.AdminApproval,
                    PaymentMode = model.PaymentMode,
                    PaymentRefNo = model.PaymentRefNo,
                    PaymentDate = model.PaymentDate,
                    Reimbursement = model.Reimbursement,
                    RemarksInternal = model.RemarksInternal,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1
                };

                await _context.FinancialStatuses.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Soft Delete Financial Record
        public async Task<bool> SoftDeleteFinancialStatusAsync(int id, int updatedBy)
        {
            try
            {
                // Find the record by ID
                var record = await _context.FinancialStatuses
                    .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

                if (record == null)
                    return false; // Record not found or already deleted

                // Mark as inactive
                record.IsActive = false;
                record.UpdatedBy = updatedBy;
                record.UpdatedDate = DateTime.Now;

                // Save changes
                _context.FinancialStatuses.Update(record);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }


        //Get data with search and pagination
        public async Task<(List<FinancialStatusVM> Items, int TotalCount)> GetFinancialStatusesAsync(FinancialStatusVM searchModel)
        {
            try
            {
                var query = _context.FinancialStatuses
                    .Where(x => x.IsActive)
                    .AsQueryable();

                // SEARCH FILTER
                if (!string.IsNullOrWhiteSpace(searchModel.SearchText))
                {
                    var s = searchModel.SearchText.Trim().ToLower();
                    query = query.Where(x =>
                        (x.Status != null && x.Status.ToLower().Contains(s)) ||
                        (x.AdminApproval != null && x.AdminApproval.ToLower().Contains(s)) ||
                        (x.PurchaseInvoice != null && x.PurchaseInvoice.ToLower().Contains(s))
                    );
                }

                // TOTAL COUNT (for pagination info)
                var totalCount = await query.CountAsync();

                // PAGINATION LOGIC
                var items = await query
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((searchModel.PageNumber - 1) * searchModel.PageSize)
                    .Take(searchModel.PageSize)
                    .Select(x => new FinancialStatusVM
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProjectId = x.ProjectId,
                        ProjectDate = x.ProjectDate,
                        Budget = x.Budget,
                        Document = x.Document,
                        Status = x.Status,
                        PurchaseInvoice = x.PurchaseInvoice,
                        ReceivedAmount = x.ReceivedAmount,
                        ExpenseAmount = x.ExpenseAmount,
                        ExpenseReason = x.ExpenseReason,
                        AdminApproval = x.AdminApproval,
                        PaymentMode = x.PaymentMode,
                        PaymentRefNo = x.PaymentRefNo,
                        PaymentDate = x.PaymentDate,
                        Reimbursement = x.Reimbursement,
                        RemarksInternal = x.RemarksInternal,
                        IsActive = x.IsActive,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    })
                    .ToListAsync();

                return (items, totalCount);
            }
            catch
            {
                return (new List<FinancialStatusVM>(), 0);
            }
        }
    }
}
