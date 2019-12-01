using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    // GET http://localhost:5000/api/Values
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // Validate request

            // Make user lowercase (so we do not get users with same name)
            username = username.ToLower();
            // If the username already exists, then we cannot create the user
            if (await _repo.UserExists(username))
            {
                return BadRequest("Username already exists");
            }
            // Create the user and register the user
            var userToCreate = new User 
            {
                Username = username
            };
            var createdUser = await _repo.Register(userToCreate, password);
            return StatusCode(201);
        }
    }
}