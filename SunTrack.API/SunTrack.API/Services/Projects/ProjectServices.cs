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
                    p.ServiceNo.ToString().ToLower().Contains(s)
                );
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
                    Category = p.Category,
                    ServiceNo = p.ServiceNo,
                })
                .ToListAsync();
            return result;
        }
    }
}