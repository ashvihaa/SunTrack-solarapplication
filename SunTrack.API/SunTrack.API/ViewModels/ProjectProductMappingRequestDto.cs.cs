using Newtonsoft.Json;

namespace SunTrack.API.ViewModels
{
    public class ProjectProductMappingRequestDto
    {
        public int ProjectId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();

        public bool IsActive { get; set; }
    }

}

//new List<int>();
// Works in any C# version.

//new();
//Requires C# 9.0 or higher (e.g., .NET 5+)