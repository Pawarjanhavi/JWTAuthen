using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] User u)
        {
            if (u.ProfilePic != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, u.ProfilePic.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await u.ProfilePic.CopyToAsync(stream);
                }

                var response = new
                {
                    Success = true,
                    Message = $"User {u.UserName} created with {u.Email}",
                    ProfilePic = u.ProfilePic.FileName,
                    Code = StatusCodes.Status200OK
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }
    }
}
