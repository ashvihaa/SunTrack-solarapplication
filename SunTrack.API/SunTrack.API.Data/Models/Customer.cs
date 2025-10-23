using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<FinancialStatus> FinancialStatuses { get; set; } = new List<FinancialStatus>();

    public virtual ICollection<InstallationStatus> InstallationStatuses { get; set; } = new List<InstallationStatus>();

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual User? UpdatedByNavigation { get; set; }
}
