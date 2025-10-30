using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class FinancialStatus
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProjectId { get; set; }

    public DateTime ProjectDate { get; set; }

    public decimal Budget { get; set; }

    public string Document { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int PurchaseInvoice { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public decimal? ReceivedAmount { get; set; }

    public decimal? ExpenseAmount { get; set; }

    public string? ExpenseReason { get; set; }

    public string? AdminApproval { get; set; }

    public string? PaymentMode { get; set; }

    public string? PaymentRefNo { get; set; }

    public DateTime? PaymentDate { get; set; }

    public bool? Reimbursement { get; set; }

    public string? RemarksInternal { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
