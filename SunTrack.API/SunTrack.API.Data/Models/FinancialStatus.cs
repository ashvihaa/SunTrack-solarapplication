using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class FinancialStatus
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProjectId { get; set; }

    public DateTime ProjectDate { get; set; }

    public decimal Amount { get; set; }

    public string Document { get; set; } = null!;

    public DateTime ApprovedRejected { get; set; }

    public string Status { get; set; } = null!;

    public int PurchaseInvoice { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
