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
                SiteLocationName = p.SiteLocationNavigation.Address1,
                StatusName = p.Status.ScreenName,
                CustomerName = p.Customer.CustomerName
            }).ToList();

            // Return the ViewModel list
            return projectList;
        }

        public async Task<List<ProjectViewModel>> GetFilteredProjects(
            int? customerId,
            int? statusId,
            string? category,
            string? projectName)
        {
            // Start from Projects table
            var query = _context.Projects.AsQueryable();

            // Apply filters only if values are provided
            if (customerId.HasValue)
                query = query.Where(p => p.CustomerId == customerId.Value);

            if (statusId.HasValue)
                query = query.Where(p => p.StatusId == statusId.Value);

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(p => p.Category.Contains(category));

            if (!string.IsNullOrWhiteSpace(projectName))
                query = query.Where(p => p.ProjectName.Contains(projectName));

            // Shape the data into your ViewModel and execute the query
            var result = await query
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    Category = p.Category,
                    ServiceNo = p.ServiceNo,
                    SiteLocationName = p.SiteLocationNavigation.Address1,
                    StatusName = p.Status.ScreenName,
                    CustomerName = p.Customer.CustomerName
                })
                .ToListAsync();
            return result;
        }
    }
}