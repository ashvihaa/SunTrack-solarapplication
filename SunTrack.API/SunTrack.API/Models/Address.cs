using System;
using System.Collections.Generic;

namespace SunTrack.API.Models;

public partial class Address
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string State { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
