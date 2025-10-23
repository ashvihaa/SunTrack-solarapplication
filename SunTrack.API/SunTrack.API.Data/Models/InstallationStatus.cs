using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class InstallationStatus
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProjectId { get; set; }

    public string? StructureMounting { get; set; }

    public string? PanelFixing { get; set; }

    public string? InverterMounting { get; set; }

    public string? AcdbAndDcdb { get; set; }

    public string? Earthing { get; set; }

    public string? Accable { get; set; }

    public string? Dccable { get; set; }

    public string? CivilWorks { get; set; }

    public string? LightArrester { get; set; }

    public string? NetMeter { get; set; }

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
