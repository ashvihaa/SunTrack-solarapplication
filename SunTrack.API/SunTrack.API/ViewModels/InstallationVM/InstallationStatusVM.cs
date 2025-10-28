namespace SunTrack.API.ViewModels.InstallationVM
{
    public class InstallationStatusVM
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProjectId { get; set; }
        public bool StructureMounting { get; set; }
        public bool PanelFixing { get; set; }
        public bool InverterMounting { get; set; }
        public bool ACDBAndDCDB { get; set; }
        public bool Earthing { get; set; }
        public bool ACCable { get; set; }
        public bool DCCable { get; set; }
        public bool CivilWorks { get; set; }
        public bool LightArrester { get; set; }
        public bool NetMeter { get; set; }

        // For filtering / searching
        public string? SearchString { get; set; }
    
        // For Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
