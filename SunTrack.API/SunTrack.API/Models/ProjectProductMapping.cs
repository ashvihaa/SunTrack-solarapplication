using System;
using System.Collections.Generic;

namespace SunTrack.API.Models;

public partial class ProjectProductMapping
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int ProductId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ProductDetail Product { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
