using System;

namespace SunTrack.API.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string? Category { get; set; }

        public int ServiceNo { get; set; }

        public string? SiteLocationName { get; set; }   // derived from SiteLocationNavigation if needed

        public string StatusName { get; set; } = string.Empty;  // derived from Status

        public string CustomerName { get; set; } = string.Empty; // derived from Customer

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedByName { get; set; } = string.Empty;  // derived from CreatedByNavigation

        public string? UpdatedByName { get; set; }                 // derived from UpdatedByNavigation
    }
}
