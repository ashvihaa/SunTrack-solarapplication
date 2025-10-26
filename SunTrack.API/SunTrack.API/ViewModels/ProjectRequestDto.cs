namespace SunTrack.API.ViewModels
{
    public class ProjectRequestDto
    {
        public int ProjectId { get; set; }
        public int Customer_Id { get; set; }
        public int? Lead_Id { get; set; }
        public int StatusId { get; set; }
        public string Project_Name { get; set; }
        public string Service_No { get; set; }
        public string Category { get; set; }
        public int SiteLocation { get; set; }
        public bool SubsidyApplicable { get; set; }
        public List<ProductsList> productsList { get; set; }
    }

    public class ProductsList
    {
        public int ProductId { get; set; }

    }
}
