using System;
using System.Collections.Generic;

namespace SunTrack.API.Models;

public partial class Lead
{
    public int Id { get; set; }

    public int ResposibleId { get; set; }

    public int CustomerId { get; set; }

    public int StatusId { get; set; }

    public string LeadNo { get; set; } = null!;

    public string Source { get; set; } = null!;

    public DateTime FollowUpDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<LeadDetail> LeadDetails { get; set; } = new List<LeadDetail>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual User Resposible { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
