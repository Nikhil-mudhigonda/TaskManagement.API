using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs.ProjectDTOs;

namespace TaskManagement.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            return await _context.Projects
                .Where(x => x.isActive)
                .Select(x => new ProjectDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();
        }

        public async Task<ProjectDTO?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .Where(x => x.Id == id && x.isActive)
                .Select(x => new ProjectDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).FirstOrDefaultAsync();
        }

        public async Task CreateProject(CreateProjectDto createProjectDto)
        {
            var pj = new Models.Project
            {
                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
            };

            _context.Projects.Add(pj);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(x => x.Id == id && x.isActive);

            if (project == null)
                return false;

            project.Name = dto.Name;
            project.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DeactivateProjectAsync(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id && x.isActive);
            if(project == null)
            {
                return false;
            }
            project.isActive = false;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
