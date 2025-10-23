using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class Project
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int LeadId { get; set; }

    public int StatusId { get; set; }

    public string ProjectName { get; set; } = null!;

    public int ServiceNo { get; set; }

    public string? Category { get; set; }

    public int SiteLocation { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<FinancialStatus> FinancialStatuses { get; set; } = new List<FinancialStatus>();

    public virtual ICollection<InstallationStatus> InstallationStatuses { get; set; } = new List<InstallationStatus>();

    public virtual Lead Lead { get; set; } = null!;

    public virtual ICollection<ProjectProductMapping> ProjectProductMappings { get; set; } = new List<ProjectProductMapping>();

    public virtual Address SiteLocationNavigation { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
