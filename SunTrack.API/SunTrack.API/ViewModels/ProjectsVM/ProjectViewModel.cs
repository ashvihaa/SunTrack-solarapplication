using System;

namespace SunTrack.API.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public required string ProjectName { get; set; }

        public string? Category { get; set; }

        public int ServiceNo { get; set; }
    }
}
