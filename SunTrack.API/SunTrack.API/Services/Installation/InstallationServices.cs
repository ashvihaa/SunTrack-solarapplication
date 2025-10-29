using SunTrack.API.Data;
using SunTrack.API.Data.Models;
using SunTrack.API.ViewModels.InstallationVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SunTrack.API.Services.Installation
{
    public class InstallationServices : IInstallationServices
    {
        private readonly SunTrackContext _context;

        public InstallationServices(SunTrackContext context)
        {
            _context = context;
        }


        public async Task<bool> AddInstallationStatusAsync(InstallationStatusVM model)
        {
            try
            {
                var entity = new InstallationStatus
                {
                    CustomerId = model.CustomerId ?? 0,
                    ProjectId = model.ProjectId ?? 0,
                    StructureMounting = model.StructureMounting,
                    PanelFixing = model.PanelFixing,
                    InverterMounting = model.InverterMounting,
                    AcdbAndDcdb = model.ACDBAndDCDB,
                    Earthing = model.Earthing,
                    Accable = model.ACCable,
                    Dccable = model.DCCable,
                    CivilWorks = model.CivilWorks,
                    LightArrester = model.LightArrester,
                    NetMeter = model.NetMeter,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1
                };

                await _context.InstallationStatuses.AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<InstallationStatusVM>> GetAllInstallationStatusesAsync()
        {
            try
            {
                var result = await _context.InstallationStatuses
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new InstallationStatusVM
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProjectId = x.ProjectId,
                        StructureMounting = x.StructureMounting ?? false,
                        PanelFixing = x.PanelFixing ?? false,
                        InverterMounting = x.InverterMounting ?? false,
                        ACDBAndDCDB = x.AcdbAndDcdb ?? false,
                        Earthing = x.Earthing ?? false,
                        ACCable = x.Accable ?? false,
                        DCCable = x.Dccable ?? false,
                        CivilWorks = x.CivilWorks ?? false,
                        LightArrester = x.LightArrester ?? false,
                        NetMeter = (bool)x.NetMeter
                    }).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                // Return empty list in case of exception
                return new List<InstallationStatusVM>();
            }
        }

        public async Task<(List<InstallationStatusVM> Items, int TotalCount)> GetInstallationStatusesAsync(string? search, int pageNumber, int pageSize)
        {
            try
            {
                var q = _context.InstallationStatuses.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var s = search.Trim();
                    q = q.Where(x =>
                        x.ProjectId.ToString().Contains(s) ||
                        x.CustomerId.ToString().Contains(s));
                }

                var total = await q.CountAsync();

                var items = await q
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new InstallationStatusVM
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        ProjectId = x.ProjectId,
                        StructureMounting = x.StructureMounting ?? false,
                        PanelFixing = x.PanelFixing ?? false,
                        InverterMounting = x.InverterMounting ?? false,
                        ACDBAndDCDB = x.AcdbAndDcdb ?? false,
                        Earthing = x.Earthing ?? false,
                        ACCable = x.Accable ?? false,
                        DCCable = x.Dccable ?? false,
                        CivilWorks = x.CivilWorks ?? false,
                        LightArrester = x.LightArrester ?? false,
                        NetMeter = x.NetMeter ?? false,
                    })
                    .ToListAsync();

                return (items, total);
            }
            catch
            {
                return (new List<InstallationStatusVM>(), 0);
            }
        }

        public async Task<bool> UpdateInstallationStatusAsync(InstallationStatusVM model)
        {
            try
            {
                // Check if the record exists
                var existing = await _context.InstallationStatuses
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (existing == null)
                    return false; // Record not found

                // Update only what’s in the model
                existing.CustomerId = (int)model.CustomerId;
                existing.ProjectId = (int)model.ProjectId;
                existing.StructureMounting = model.StructureMounting;
                existing.PanelFixing = model.PanelFixing;
                existing.InverterMounting = model.InverterMounting;
                existing.AcdbAndDcdb = model.ACDBAndDCDB;
                existing.Earthing = model.Earthing;
                existing.Accable = model.ACCable;
                existing.Dccable = model.DCCable;
                existing.CivilWorks = model.CivilWorks;
                existing.LightArrester = model.LightArrester;
                existing.NetMeter = model.NetMeter;
                existing.UpdatedDate = DateTime.Now;
                existing.UpdatedBy = 1; // Replace with logged-in user id

                // Save to DB
                _context.InstallationStatuses.Update(existing);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}

        
