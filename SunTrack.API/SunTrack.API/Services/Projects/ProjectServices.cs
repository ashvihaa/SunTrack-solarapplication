using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunTrack.API.Data.Models;
using SunTrack.API.Services.Projects;
using SunTrack.API.ViewModels;

namespace SunTrackApi.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly SunTrackContext _context;

        public ProjectServices(SunTrackContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectslist()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<List<ProjectViewModel>> GetAllProjectsAsync()
        {
            // Get all projects from database and include related data
            var projects = await _context.Projects
                .Include(p => p.Customer)              // get Customer details
                .Include(p => p.Status)                // get Status details
                .Include(p => p.SiteLocationNavigation)// get Site Location details
                .ToListAsync();

            var projectList = projects.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                Category = p.Category,
                ServiceNo = p.ServiceNo,
            }).ToList();

            // Return the ViewModel list
            return projectList;
        }

        public async Task<List<ProjectViewModel>> GetProjectsAsync(SearchVM search)
        {
            // Start the query
            var query = _context.Projects
                .AsNoTracking()
                .AsQueryable();

            // Apply search filter if text is provided
            if (!string.IsNullOrWhiteSpace(search.SearchText))
            {
                var s = search.SearchText.Trim().ToLower();
                query = query.Where(p =>
                    (p.ProjectName != null && p.ProjectName.ToLower().Contains(s)) ||
                    (p.Category != null && p.Category.ToLower().Contains(s)) ||
                    p.ServiceNo.ToString().ToLower().Contains(s));
            }

            // Pagination logic
            int skip = (search.PageNumber - 1) * search.PageSize;

            // Execute LINQ query
            var result = await query
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(search.PageSize)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    Category = p.Category ?? string.Empty, // Fix CS8601 here
                    ServiceNo = p.ServiceNo,
                })
                .ToListAsync();
            return result;
        }

        public async Task<string> SaveProjectAsync(ProjectRequestDto model)
        {
            if (model == null)
                return "Invalid data";

            // ADD 
            if (model.ProjectId == 0)
            {
                var project = new Project
                {
                    CustomerId = model.Customer_Id,
                    LeadId = model.Lead_Id ?? 0,
                    StatusId = model.StatusId,
                    ProjectName = model.Project_Name,
                    ServiceNo = int.TryParse(model.Service_No, out var serviceNo) ? serviceNo : 0,
                    Category = model.Category,
                    SiteLocation = model.SiteLocation,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    IsActive = true
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return "Project added successfully";
            }
            else
            {
                // EDIT
                var existingProject = await _context.Projects
                    .FirstOrDefaultAsync(x => x.Id == model.ProjectId);

                if (existingProject == null)
                    return "Project not found";

                existingProject.CustomerId = model.Customer_Id;
                existingProject.LeadId = model.Lead_Id ?? 0;
                existingProject.StatusId = model.StatusId;
                existingProject.ProjectName = model.Project_Name;
                existingProject.ServiceNo = int.TryParse(model.Service_No, out var serviceNo) ? serviceNo : 0;
                existingProject.Category = model.Category;
                existingProject.SiteLocation = model.SiteLocation;
                existingProject.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return "Project updated successfully";
            }
        }

        public async Task<ProjectRequestDto> GetProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(x => x.Id == projectId);

            if (project == null)
                return null;

            return new ProjectRequestDto
            {
                ProjectId = project.Id,
                Customer_Id = project.CustomerId,
                Lead_Id = project.LeadId,
                StatusId = project.StatusId,
                Project_Name = project.ProjectName,
                Service_No = project.ServiceNo.ToString(),
                Category = project.Category,
                SiteLocation = project.SiteLocation,
            };
        }

        public async Task<List<ProjectRequestDto>> GetAllProjectsDtoAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            var list = new List<ProjectRequestDto>();

            foreach (var p in projects)
            {
                list.Add(new ProjectRequestDto
                {
                    ProjectId = p.Id,
                    Customer_Id = p.CustomerId,
                    Lead_Id = p.LeadId,
                    StatusId = p.StatusId,
                    Project_Name = p.ProjectName,
                    Service_No = p.ServiceNo.ToString(),
                    Category = p.Category,
                    SiteLocation = p.SiteLocation,
                });
            }
            return list;
        }

        public async Task<string> AddOrUpdateMappingAsync(ProjectProductMappingRequestDto model)
        {
            if (model == null || model.ProjectId <= 0)
                return "Invalid data";

            var existing = _context.ProjectProductMappings
                .Where(x => x.ProjectId == model.ProjectId);
            _context.ProjectProductMappings.RemoveRange(existing);
            await _context.SaveChangesAsync();

            if (model.ProductIds != null && model.ProductIds.Any())
            {
                foreach (var productId in model.ProductIds)
                {
                    _context.ProjectProductMappings.Add(new ProjectProductMapping
                    {
                        ProjectId = model.ProjectId,
                        ProductId = productId
                    });
                }
                await _context.SaveChangesAsync();
            }

            return "Mapping saved successfully";
        }

        public async Task<List<int>> GetProductIdsByProjectAsync(int projectId)
        {
            return await _context.ProjectProductMappings
                .Where(x => x.ProjectId == projectId)
                .Select(x => x.ProductId)
                .ToListAsync();
        }

        //public async Task<string> DeleteProjectAsync(int projectId)
        //{
        //    // Validate input
        //    if (projectId <= 0)
        //        return "Invalid project ID";

        //    // Find project
        //    var project = await _context.Projects
        //        .FirstOrDefaultAsync(p => p.Id == projectId);

        //    if (project == null)
        //        return "Project not found";

        //    // Remove product mappings first (optional but recommended)
        //    var existingMappings = _context.ProjectProductMappings
        //        .Where(x => x.ProjectId == projectId);
        //    _context.ProjectProductMappings.RemoveRange(existingMappings);

        //    // Remove the project
        //    _context.Projects.Remove(project);

        //    // Save changes
        //    await _context.SaveChangesAsync();

        //    return "Project deleted successfully";
        //}

        public async Task<string> DeleteProjectAsync(int projectId)
        {
            // Validate
            if (projectId <= 0)
                return "Invalid project ID";

            // Get the project
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                return "Project not found";

            // Soft delete project
            project.IsActive = false;
            project.UpdatedDate = DateTime.Now;

            // Soft delete related product mappings
            var mappings = _context.ProjectProductMappings
                .Where(m => m.ProjectId == projectId && m.IsActive == true)
                .ToList();

            foreach (var mapping in mappings)
            {
                mapping.IsActive = false;
                mapping.UpdatedDate = DateTime.Now;
            }

            // Save changes
            await _context.SaveChangesAsync();

            return "Project and its product mappings deactivated successfully";
        }

        public async Task<List<int>> GetProductIdsByProject(int projectId)
        {
            return await _context.ProjectProductMappings
                .Where(x => x.ProjectId == projectId && x.IsActive == true)  // filter active mappings
                .Select(x => x.ProductId)
                .ToListAsync();
        }
        public async Task<string> RestoreProjectAsync(int projectId)
        {
            // Validate
            if (projectId <= 0)
                return "Invalid project ID";

            // Find project
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                return "Project not found";

            // Restore project
            project.IsActive = true;
            project.UpdatedDate = DateTime.Now;

            // Optional: Restore related mappings
            var mappings = _context.ProjectProductMappings
                .Where(m => m.ProjectId == projectId)
                .ToList();

            foreach (var mapping in mappings)
            {
                mapping.IsActive = true;
                mapping.UpdatedDate = DateTime.Now;
            }

            // Save changes
            await _context.SaveChangesAsync();

            return "Project and related mappings restored successfully";
        }

    }
}