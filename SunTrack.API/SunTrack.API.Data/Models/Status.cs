using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusType { get; set; } = null!;

    public string ScreenName { get; set; } = null!;

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
