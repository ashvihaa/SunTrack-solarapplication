
//{
//    public class SearchVM
//    {
//    }
//}

namespace SunTrack.API.ViewModels
{
    public class SearchVM
    {
        public string? SearchText { get; set; }    // For searching projects
        public int PageNumber { get; set; } = 1;   // Default page number
        public int PageSize { get; set; } = 10;    // Default page size
    }

}

