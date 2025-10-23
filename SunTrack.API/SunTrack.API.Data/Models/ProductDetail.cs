using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class ProductDetail
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public string SerialNo { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public string QuantityUnits { get; set; } = null!;

    public int Capacity { get; set; }

    public string CapacityUnits { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<ProjectProductMapping> ProjectProductMappings { get; set; } = new List<ProjectProductMapping>();

    public virtual Lead? UpdatedByNavigation { get; set; }
}
