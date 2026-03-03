using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs.ProjectDTOs;
using TaskManagement.API.Services;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        //[HttpGet("index")]
        //public IActionResult Index()
        //{
        //    return Ok();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            await _projectService.CreateProject(createProjectDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, UpdateProjectDto updateProjectDto)
        {
            var result = await _projectService.UpdateProjectAsync(id, updateProjectDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}/deactivate")]
        public async Task<ActionResult> DeactivateProject(int id)
        {
            var result = await _projectService.DeactivateProjectAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
