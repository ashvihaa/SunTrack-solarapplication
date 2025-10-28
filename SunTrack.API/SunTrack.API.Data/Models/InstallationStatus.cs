using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class InstallationStatus
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProjectId { get; set; }

    public bool? StructureMounting { get; set; }

    public bool? PanelFixing { get; set; }

    public bool? InverterMounting { get; set; }

    public bool? AcdbAndDcdb { get; set; }

    public bool? Earthing { get; set; }

    public bool? Accable { get; set; }

    public bool? Dccable { get; set; }

    public bool? CivilWorks { get; set; }

    public bool? LightArrester { get; set; }

    public bool? NetMeter { get; set; }

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
