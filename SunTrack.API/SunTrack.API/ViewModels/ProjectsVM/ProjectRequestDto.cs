namespace SunTrack.API.ViewModels.ProjectsVM
{
    public class ProjectRequestDto
    {
        public int ProjectId { get; set; }
        public int Customer_Id { get; set; }
        public int? LeadId { get; set; }
        public int StatusId { get; set; }
        public string Project_Name { get; set; }
        public int ServiceNo { get; set; }
        public string Category { get; set; }
        public int SiteLocation { get; set; }
        public bool SubsidyApplicable { get; set; }
        public int CustomerId { get; set; }
        public decimal SystemCapacityKW { get; set; }
        public bool IsActive { get; set; } = true;
        
        public int CreatedBy { get; set; }

        public List<int> ProductIds { get; set; } = new();
    
    }

}

