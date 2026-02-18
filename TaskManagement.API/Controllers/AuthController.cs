using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs;
using TaskManagement.API.Models;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        public AuthController(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new ApplicationUsers
            {
                UserName = dto.Email,
                Email = dto.Email
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, dto.Role);
            return Ok("user created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginRequestDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return Ok("user logged in successfully");
        }
    }
}
