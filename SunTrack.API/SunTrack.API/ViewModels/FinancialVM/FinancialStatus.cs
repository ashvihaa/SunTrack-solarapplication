namespace SunTrack.API.ViewModels.FinancialVM
{
    public class FinancialStatusVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? ProjectDate { get; set; }
        public decimal? Budget { get; set; }
        public string? Document { get; set; }
        public string? Status { get; set; }
        public string? PurchaseInvoice { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public string? ExpenseReason { get; set; }
        public string? AdminApproval { get; set; }
        public string? PaymentMode { get; set; }
        public string? PaymentRefNo { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? Reimbursement { get; set; }
        public string? RemarksInternal { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
