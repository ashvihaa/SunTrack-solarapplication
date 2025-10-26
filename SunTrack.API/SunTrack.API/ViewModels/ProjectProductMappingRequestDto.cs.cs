namespace SunTrack.API.ViewModels
{
    public class ProjectProductMappingRequestDto
    {
        public int ProjectId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
    }

}
